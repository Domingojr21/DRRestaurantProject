

using DRRestaurant.Core.Domain.EntitiesAbstraction;

namespace DRRestaurant.Core.Domain.Entities
{
    public class Ingredient : ICommonProperties
    {
        public int Id { get; set; }
        public bool Status { get; set; } = true;
        public string Name { get; set; } = null!;
        public ICollection<DishIngredients> DishIngredients { get; set; } = null!;

    }
}
