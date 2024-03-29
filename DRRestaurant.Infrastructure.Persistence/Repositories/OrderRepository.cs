using DRRestaurant.Core.Application.Interfaces.Repositories;
using DRRestaurant.Core.Domain.Entities;
using DRRestaurant.Infrastructure.Identity.Context;
using Microsoft.EntityFrameworkCore;


namespace DRRestaurant.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly RestaurantContext _context;
        public OrderRepository(RestaurantContext restaurantContext) : base(restaurantContext)
        {
            _context = restaurantContext;
        }

        public async Task ChangeStatusToIsCompleted(int id)
        {
            var vm = await GetByIdAsync(id);
            _context.Entry(vm).Property("IsCompleted").CurrentValue = true;
            _context.SaveChanges();
        }
    }
}
