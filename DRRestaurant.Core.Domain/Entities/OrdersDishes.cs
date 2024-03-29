using DRRestaurant.Core.Domain.EntitiesAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRestaurant.Core.Domain.Entities
{
    public class OrdersDishes : ICommonProperties
    {
        public int Id { get; set; }
        public bool Status { get; set; } = true;
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public int DishId { get; set; }
        public Dish Dish { get; set; } = null!;
    }
}
