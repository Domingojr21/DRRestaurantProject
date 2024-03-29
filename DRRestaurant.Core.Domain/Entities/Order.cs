

using DRRestaurant.Core.Domain.EntitiesAbstraction;

namespace DRRestaurant.Core.Domain.Entities
{
    public class Order : ICommonProperties
    {
        public int Id { get; set; }
        public bool Status { get; set; } = true;
        public int TableId { get; set; }
        public Table Table { get; set; } = null!;
        public ICollection<OrdersDishes> Dishes { get; set; } = null!;
        public double SubTotal { get; set; }
        public bool IsCompleted { get; set; } = false;

    }
}
