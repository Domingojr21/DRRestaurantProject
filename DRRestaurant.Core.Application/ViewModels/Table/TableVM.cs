using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRestaurant.Core.Application.ViewModels.Table
{
    public class TableVM
    {
        public int Id { get; set; }
        public int QuantityOfPersonOntheTable { get; set; }
        public string Description { get; set; } = null!;
        public string TableStatus { get; set; } = null!;
    }
}
