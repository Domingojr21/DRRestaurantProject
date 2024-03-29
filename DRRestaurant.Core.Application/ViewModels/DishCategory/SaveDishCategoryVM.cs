using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRestaurant.Core.Application.ViewModels.DishCategory
{
    public class SaveDishCategoryVM
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
