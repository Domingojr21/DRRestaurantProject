using DRRestaurant.Core.Application.Interfaces.Repositories;
using DRRestaurant.Core.Domain.EntitiesAbstraction;
using DRRestaurant.Infrastructure.Identity.Context;
using Microsoft.EntityFrameworkCore;


namespace DRRestaurant.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<E> : IGenericRepository<E> where E : class, ICommonProperties
    {
        private readonly RestaurantContext _restaurantContext;

        public GenericRepository(RestaurantContext restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }

        public virtual async Task<List<E>> GetAllAsync()
        {
            var list = _restaurantContext.Set<E>().Where(e => e.Status == true).ToList();
            return list;
        }

        public virtual async Task<E> GetByIdAsync(int id)
        {
            var entity = await _restaurantContext.Set<E>().FindAsync(id);

            if (entity == null || entity.Status != true)
            {
                return null;
            }

            return entity;
        }

        public virtual async Task DeleteAsync(E entity)
        {
           _restaurantContext.Entry(entity).Property("Status").CurrentValue = false;
            await _restaurantContext.SaveChangesAsync();
        }

        public virtual async Task<E> AddAsync(E entity)
        {
            await _restaurantContext.AddAsync(entity);
            _restaurantContext.SaveChanges();
            return entity;
        }
        public virtual async Task UpdateAsync(E entity, int id)
        {
            var entry = await _restaurantContext.Set<E>().FindAsync(id);
            _restaurantContext.Entry(entry).CurrentValues.SetValues(entity);
            await _restaurantContext.SaveChangesAsync();
        }

        public virtual async Task<List<E>> GetAllWithInclude(List<string> Properties)
        {
            var query = _restaurantContext.Set<E>().AsQueryable();

            foreach (var property in Properties)
            {
                query.Include(property);
            }

            return await query.Where(x => x.Status == true).ToListAsync();
        }

    }
}
