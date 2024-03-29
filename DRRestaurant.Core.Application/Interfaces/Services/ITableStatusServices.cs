using DRRestaurant.Core.Application.ViewModels.TableStatus;
using DRRestaurant.Core.Domain.Entities;

namespace DRRestaurant.Core.Application.Interfaces.Services
{
    public interface ITableStatusServices : IGenericService<SaveTableStatusVM,TableStatusVM,TableStatus>
    {
    }
}
