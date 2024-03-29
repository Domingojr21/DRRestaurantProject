using DRRestaurant.Core.Application.Interfaces.Repositories;
using DRRestaurant.Core.Domain.Entities;
using DRRestaurant.Infrastructure.Identity.Context;
using Microsoft.EntityFrameworkCore;


namespace DRRestaurant.Infrastructure.Persistence.Repositories
{
    public class TableRepository : GenericRepository<Table>, ITableRepository
    {
        private readonly RestaurantContext _restaurantContext;
        public TableRepository(RestaurantContext restaurantContext) : base(restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }

        public override Task<List<Table>> GetAllWithInclude(List<string> Properties)
        {
            var query = _restaurantContext.Set<Table>().AsQueryable();

            foreach (var property in Properties)
            {
                query = query.Include(property);
            }

            return query.ToListAsync();
        }

        public async Task ChangeStatus(int tableId, int tableStatusId)
        {
            var vm = await GetByIdAsync(tableId);
            _restaurantContext.Entry(vm).Property("TableStatusId").CurrentValue = tableStatusId;
            _restaurantContext.SaveChanges();
        }
    }
}
