using DRRestaurant.Core.Domain.EntitiesAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRestaurant.Core.Domain.Entities
{
    public class Table : ICommonProperties
    {
        public int Id { get; set; }
        public bool Status { get; set; } = true;
        public int QuantityOfPersonOntheTable { get; set; }
        public string Description { get; set; } = null!;
        public int TableStatusId { get; set; }
        public TableStatus TableStatus { get; set; } = null!;
    }
}
