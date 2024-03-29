using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRestaurant.Core.Application.ViewModels.TableStatus
{
    public class TableStatusVM
    {
        public int Id { get; set; }
        public string TableStatusName { get; set; } = null!;
    }
}
