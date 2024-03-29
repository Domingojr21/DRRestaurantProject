using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DRRestaurant.Core.Application.ViewModels.Table
{
    public class SaveTableVM
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int QuantityOfPersonOntheTable { get; set; }
        public string Description { get; set; } = null!;
        [JsonIgnore]
        public int TableStatusId { get; set; } = 1;
    }
}
