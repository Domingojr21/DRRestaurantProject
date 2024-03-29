using DRRestaurant.Core.Domain.EntitiesAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRestaurant.Core.Domain.Entities
{
    public class DishCategory : ICommonProperties
    {
        public int Id { get; set; }
        public bool Status { get; set; } = true;
        public string CategoryName { get; set; } = null!;
        public ICollection<Dish> Dishes { get; set; } = null!;
    }
}
