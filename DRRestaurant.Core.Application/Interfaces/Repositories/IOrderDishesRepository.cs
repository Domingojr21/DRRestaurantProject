using DRRestaurant.Core.Domain.Entities;


namespace DRRestaurant.Core.Application.Interfaces.Repositories
{
    public interface IOrderDishesRepository : IGenericRepository<OrdersDishes>
    {
       public void DeleteByOrderhId(int orderId);
    }
}
