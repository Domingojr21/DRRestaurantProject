using DRRestaurant.Core.Domain.EntitiesAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRestaurant.Core.Domain.Entities
{
    public class DishIngredients : ICommonProperties
    {
        public int Id { get; set; }
        public bool Status { get; set; } = true;
        public int DishId { get; set; }
        public Dish Dish { get; set; } = null!;
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } = null!;
    }
}
