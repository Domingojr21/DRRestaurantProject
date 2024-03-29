using DRRestaurant.Core.Application.Interfaces.Repositories;
using DRRestaurant.Core.Domain.Entities;
using DRRestaurant.Infrastructure.Identity.Context;
using Microsoft.EntityFrameworkCore;


namespace DRRestaurant.Infrastructure.Persistence.Repositories
{
    public class OrderDishesRepository : GenericRepository<OrdersDishes>, IOrderDishesRepository
    {
        private readonly RestaurantContext _dbContext;
        public OrderDishesRepository(RestaurantContext restaurantContext) : base(restaurantContext)
        {
            _dbContext = restaurantContext;
        }

        public void DeleteByOrderhId(int orderId)
        {
            var list = _dbContext.OrdersDishes.Where(x => x.OrderId == orderId).ToList();

            foreach (var dishOrder in list)
            {
                _dbContext.Remove(dishOrder);
            }
        }

        public override async Task<List<OrdersDishes>> GetAllWithInclude(List<string> properties)
        {
            var query = _dbContext.Set<OrdersDishes>().AsQueryable();

            foreach (var property in properties)
            {
                query = query.Include(property);
            }

            return await query.ToListAsync();
        }
    }
}
