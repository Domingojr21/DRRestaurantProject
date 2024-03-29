using DRRestaurant.Core.Application.ViewModels.Dish;
using DRRestaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRestaurant.Core.Application.Interfaces.Services
{
    public interface IDishServices : IGenericService<SaveDishVM,DishVM,Dish>
    {
        Task<DishVM> GetByIdViewModel(int id);
        Task<List<DishVM>> GetAllViewModelWithInclude();
    }
}
