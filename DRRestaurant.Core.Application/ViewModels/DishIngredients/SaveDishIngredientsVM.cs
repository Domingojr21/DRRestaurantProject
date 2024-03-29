using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRestaurant.Core.Application.ViewModels.DishIngredients
{
    public class SaveDishIngredientsVM
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public int IngredientId { get; set; }
    }
}
