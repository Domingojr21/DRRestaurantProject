using System.Text.Json.Serialization;

namespace DRRestaurant.Core.Application.ViewModels.Dish
{
   public class SaveDishVM
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public int QuantityOfPeople { get; set; }
        public List<int> Ingredients { get; set; } = new();
        public int CategoryId { get; set; }
    }
}
