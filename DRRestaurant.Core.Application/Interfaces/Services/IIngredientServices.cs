using DRRestaurant.Core.Application.ViewModels.Ingredient;
using DRRestaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRestaurant.Core.Application.Interfaces.Services
{
    public interface IIngredientServices : IGenericService<SaveIngredientVM,IngredientVM,Ingredient>
    {
    }
}
