using DRRestaurant.Core.Application.Services;
using DRRestaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRestaurant.Core.Application.Interfaces.Repositories
{
    public interface IDishIngredientRepository : IGenericRepository<DishIngredients>
    {
        void DeleteByDishId(int DishId);
    }
}
