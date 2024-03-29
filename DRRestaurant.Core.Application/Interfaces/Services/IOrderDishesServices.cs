using DRRestaurant.Core.Application.ViewModels.Dish;
using DRRestaurant.Core.Application.ViewModels.OrderDishes;
using DRRestaurant.Core.Domain.Entities;

namespace DRRestaurant.Core.Application.Interfaces.Services
{
    public interface IOrderDishesServices : IGenericService<SaveOrderDishVM, OrderDishVM, OrdersDishes>
    {
        void DeleteByOrderhId(int orderId);
        Task<List<DishForOrderVM>> GetDishesByOrderId(int orderId);
    }
}
