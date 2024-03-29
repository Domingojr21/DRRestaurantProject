using DRRestaurant.Core.Application.ViewModels.DishIngredients;
using DRRestaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRestaurant.Core.Application.Interfaces.Services
{
    public interface IDishIngredientServices : IGenericService<SaveDishIngredientsVM, DishIngredientsVM, Ingredient>
    {
        void DeleteByDishId(int DishId);
        Task<List<string>> GetIngredientsByDishId(int DishId);
    }
}
