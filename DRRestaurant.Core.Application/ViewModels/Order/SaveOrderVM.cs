
using System.Text.Json.Serialization;

namespace DRRestaurant.Core.Application.ViewModels.Order
{
    public class SaveOrderVM
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int TableId { get; set; }
        public List<int> DishesToSelectIds { get; set; } = null!;
        [JsonIgnore]
        public double SubTotal { get; set; }
    }
}
