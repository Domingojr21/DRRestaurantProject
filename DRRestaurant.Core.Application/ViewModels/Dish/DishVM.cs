
using System.Text.Json.Serialization;

namespace DRRestaurant.Core.Application.ViewModels.Dish
{
    public class DishVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public int QuantityOfPeople { get; set; }
        public List<string>? Ingredients { get; set; } = null!;
        [JsonIgnore]
        public int CategoryId { get; set; }
        public string Category { get; set; } = null!;
    }
}
