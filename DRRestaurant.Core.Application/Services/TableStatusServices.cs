using AutoMapper;
using DRRestaurant.Core.Application.Interfaces.Repositories;
using DRRestaurant.Core.Application.Interfaces.Services;
using DRRestaurant.Core.Application.ViewModels.TableStatus;
using DRRestaurant.Core.Domain.Entities;

namespace DRRestaurant.Core.Application.Services
{
    public class TableStatusServices : GenericServices<SaveTableStatusVM, TableStatusVM, TableStatus>, ITableStatusServices
    {
        private readonly ITableStatusRepository _tableStatusRepository;
        private readonly IMapper _mapper;

        public TableStatusServices(ITableStatusRepository tableStatusRepository, IMapper mapper) : base(tableStatusRepository, mapper)
        {
            _tableStatusRepository = tableStatusRepository;
            _mapper = mapper;
        }
    }
}
