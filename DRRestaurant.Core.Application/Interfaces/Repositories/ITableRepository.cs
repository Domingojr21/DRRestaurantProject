using DRRestaurant.Core.Domain.Entities;


namespace DRRestaurant.Core.Application.Interfaces.Repositories
{
    public interface ITableRepository : IGenericRepository<Table>
    {
        Task ChangeStatus(int tableId, int tableStatusId);
    }
}
