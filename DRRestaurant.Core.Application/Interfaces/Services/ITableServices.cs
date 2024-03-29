using DRRestaurant.Core.Application.ViewModels.Table;
using DRRestaurant.Core.Domain.Entities;


namespace DRRestaurant.Core.Application.Interfaces.Services
{
    public interface ITableServices : IGenericService<SaveTableVM,TableVM,Table>
    {
        Task<List<TableVM>> GetAllVM();
        Task ChangeStatus(int tableId, int tableStatusId);
        Task<TableVM> GetTableById(int id);
    }
}
