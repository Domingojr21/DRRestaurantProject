using DRRestaurant.Core.Application.ViewModels.DishCategory;
using DRRestaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRestaurant.Core.Application.Interfaces.Services
{
    public interface IDishCategoryServices : IGenericService<SaveDishCategoryVM, DishCategoryVM, DishCategory>
    {
    }
}
