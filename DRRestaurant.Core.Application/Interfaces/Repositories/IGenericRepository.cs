using DRRestaurant.Core.Domain.EntitiesAbstraction;

namespace DRRestaurant.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<E> where E : class
    {
        Task<E> AddAsync(E entity);
        Task<List<E>> GetAllAsync();
        Task<List<E>> GetAllWithInclude(List<string> Properties);
        Task<E> GetByIdAsync(int id);
        Task UpdateAsync(E entity, int id);
        Task DeleteAsync(E entity);
    }
}