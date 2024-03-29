using AutoMapper;
using DRRestaurant.Core.Application.Interfaces.Repositories;
using DRRestaurant.Core.Application.Interfaces.Services;
using DRRestaurant.Core.Application.ViewModels.Order;
using DRRestaurant.Core.Application.ViewModels.OrderDishes;
using DRRestaurant.Core.Application.ViewModels.Table;
using DRRestaurant.Core.Domain.Entities;

namespace DRRestaurant.Core.Application.Services
{
    public class OrderServices : GenericServices<SaveOrderVM, OrderVM, Order>, IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IDishServices _dishServices;
        private readonly ITableServices _tableServices;
        private readonly IOrderDishesServices _orderDishesServices;

        public OrderServices(IOrderRepository orderRepository
            , IMapper mapper,
            IDishServices dishServices,
            ITableServices tableServices,
            IOrderDishesServices orderDishesServices) : base(orderRepository, mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _dishServices = dishServices;
            _tableServices = tableServices;
            _orderDishesServices = orderDishesServices;
        }

        public override async Task<SaveOrderVM> Add(SaveOrderVM vm)
        {
            var dishListIds = vm.DishesToSelectIds;
            var dishGeneralList = await _dishServices.GetAllViewModel();
            var tabletList = await _tableServices.GetAllViewModel();
            var orderList = await GetAllViewModel();

            bool tableExist = tabletList.Exists(x => x.Id == vm.TableId);
            if (tableExist)
            {
                vm = await base.Add(vm);
                foreach (var dish in dishListIds)
                {

                    bool dishExists = dishGeneralList.Exists(x => x.Id == dish);
                    double dishTocalculate = dishGeneralList.Where(x => x.Id == dish).Select(x => x.Price).FirstOrDefault();
                    if (dishExists)
                    {
                        await _orderDishesServices.Add(new SaveOrderDishVM
                        {
                            DishId = dish,
                            OrderId = vm.Id
                        });
                    }
                    vm.SubTotal += dishTocalculate;
                }
               var order = _mapper.Map<Order>(vm);
                await _orderRepository.UpdateAsync(order, vm.Id);
            }
            else
            {
                return null;
            }


            return vm;
        }

        public async Task UpdateOrderDish(UpdateOrderViewModel uvm, int id)
        {
            _orderDishesServices.DeleteByOrderhId(id);
            var dishGeneralList = await _dishServices.GetAllViewModel();
            var tabletList = await _tableServices.GetAllViewModel();
            var ordervm = await _orderRepository.GetByIdAsync(id);

            bool tableExist = tabletList.Exists(x => x.Id == ordervm.Id);
            if (tableExist)
            {
                ordervm.SubTotal = 0;
                foreach (var dish in uvm.DishesToUpdateForOrder)
                {

                    bool dishExists = dishGeneralList.Exists(x => x.Id == dish);
                    double dishTocalculate = dishGeneralList.Where(x => x.Id == dish).Select(x => x.Price).FirstOrDefault();
                    if (dishExists)
                    {
                        await _orderDishesServices.Add(new SaveOrderDishVM
                        {
                            DishId = dish,
                            OrderId = id
                        });
                    }
                    ordervm.SubTotal += dishTocalculate;
                }


            } 
            
           await _orderRepository.UpdateAsync(ordervm, id);
        }

        public async Task<List<OrderVM>> GetAllVMWithInclude()
        {
            var list = await GetAllViewModel();

            List<OrderVM> orders = new();

           foreach(var order in list)
            {
                order.DishesSelected = await _orderDishesServices.GetDishesByOrderId(order.Id);
                orders.Add(order);
            }

            return orders;
        }

        public async Task<OrderVM> GetByOrderIdVM(int Id)
        {
            var list = await GetAllViewModel();

            List<OrderVM> orders = new();

            foreach (var order in list)
            {
                order.DishesSelected = await _orderDishesServices.GetDishesByOrderId(order.Id);
                orders.Add(order);
            }

            return orders.Where(x => x.Id == Id).FirstOrDefault();
        }

        public async Task<List<OrderVM>> GetOrdersByTableId(int tableId)
        {
            var list = await GetAllVMWithInclude();
            return list.Where(x => x.TableId == tableId && x.IsCompleted == false).ToList();
        }

        public async Task ChangeStatusToIsCompleted(int id)
        {
            await _orderRepository.ChangeStatusToIsCompleted(id);
        }
    }
}
