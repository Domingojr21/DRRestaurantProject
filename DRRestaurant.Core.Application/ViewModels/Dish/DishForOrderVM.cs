using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRestaurant.Core.Application.ViewModels.Dish
{
    public class DishForOrderVM
    {
        public string DishName { get; set; } = null!;
        public double Price { get; set; }
    }
}
