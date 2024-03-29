

using DRRestaurant.Core.Domain.EntitiesAbstraction;

namespace DRRestaurant.Core.Domain.Entities
{
    public class Dish : ICommonProperties
    {
        public int Id { get; set; }
        public bool Status { get; set; } = true;
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public int QuantityOfPeople { get; set; }
        public ICollection<DishIngredients>? DishIngredients { get; set; } = null!;
        public ICollection<OrdersDishes>? Orders { get; set; } = null!;
        public int CategoryId { get; set; }
        public DishCategory Category { get; set; } = null!;
    }
}
