using DRRestaurant.Core.Application.ViewModels.Order;
using DRRestaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRestaurant.Core.Application.Interfaces.Services
{
    public interface IOrderServices : IGenericService<SaveOrderVM,OrderVM,Order>
    {
        Task UpdateOrderDish(UpdateOrderViewModel uvm, int id);
        Task<OrderVM> GetByOrderIdVM(int Id);
        Task<List<OrderVM>> GetAllVMWithInclude();
        Task<List<OrderVM>> GetOrdersByTableId(int tableId);
        Task ChangeStatusToIsCompleted(int id);
    }
}
