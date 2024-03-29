using AutoMapper;
using DRRestaurant.Core.Application.Interfaces.Repositories;
using DRRestaurant.Core.Application.Interfaces.Services;
using DRRestaurant.Core.Application.ViewModels.Dish;
using DRRestaurant.Core.Application.ViewModels.OrderDishes;
using DRRestaurant.Core.Domain.Entities;

namespace DRRestaurant.Core.Application.Services
{
    public class OrderDishesServices : GenericServices<SaveOrderDishVM, OrderDishVM, OrdersDishes>, IOrderDishesServices
    {
        private readonly IOrderDishesRepository _orderDihesRepository;
        private readonly IMapper _mapper;

        public OrderDishesServices(IOrderDishesRepository orderDihesRepository, IMapper mapper) : base(orderDihesRepository, mapper )
        {
            _orderDihesRepository = orderDihesRepository;
            _mapper = mapper;
        }

        public void DeleteByOrderhId(int orderId)
        {
            _orderDihesRepository.DeleteByOrderhId(orderId);
        }

        public async Task<List<DishForOrderVM>> GetDishesByOrderId(int orderId)
        {
            var list = await _orderDihesRepository.GetAllWithInclude(new List<string> { "Dish", "Order" });
            List<DishForOrderVM> orderDishes = new();
            list = list.Where(x => x.OrderId == orderId).ToList();

            foreach (var order in list)
            {
                var dish = new DishForOrderVM()
                {
                    DishName = order.Dish.Name,
                    Price = order.Dish.Price,
                };
                orderDishes.Add(dish);
            }
            return orderDishes;
        }
    }
}
