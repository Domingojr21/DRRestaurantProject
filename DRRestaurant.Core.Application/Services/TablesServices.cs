

using AutoMapper;
using DRRestaurant.Core.Application.Interfaces.Repositories;
using DRRestaurant.Core.Application.Interfaces.Services;
using DRRestaurant.Core.Application.ViewModels.Order;
using DRRestaurant.Core.Application.ViewModels.Table;
using DRRestaurant.Core.Domain.Entities;

namespace DRRestaurant.Core.Application.Services
{
    public class TablesServices : GenericServices<SaveTableVM, TableVM, Table>, ITableServices
    {
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;

        public TablesServices(ITableRepository tableRepository, IMapper mapper) : base(tableRepository, mapper)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
        }

        public async Task<List<TableVM>> GetAllVM()
        {
            var list = await _tableRepository.GetAllWithInclude(new List<string> { "TableStatus" });

            return list.Select(table => new TableVM
            {
                Id = table.Id,
                Description = table.Description,
                QuantityOfPersonOntheTable = table.QuantityOfPersonOntheTable,
                TableStatus = table.TableStatus.TableStatusName
            }).ToList();
        }

        public async Task<TableVM> GetTableById(int id)
        {
            var list = await _tableRepository.GetAllWithInclude(new List<string> { "TableStatus" });

            return list.Select(table => new TableVM
            {
                Id = table.Id,
                Description = table.Description,
                QuantityOfPersonOntheTable = table.QuantityOfPersonOntheTable,
                TableStatus = table.TableStatus.TableStatusName
            }).Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task ChangeStatus(int tableId, int tableStatusId)
        {
            await _tableRepository.ChangeStatus(tableId,tableStatusId);
        }
    }
  
}
