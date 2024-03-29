using DRRestaurant.Core.Domain.EntitiesAbstraction;

namespace DRRestaurant.Core.Domain.Entities
{
    public class TableStatus : ICommonProperties
    {
        public int Id { get; set; }
        public bool Status { get; set; } = true;
        public string TableStatusName { get; set; } = null!;
        public ICollection<Table> Tables { get; set; } = null!;
    }
}
