
using DRRestaurant.Core.Application.ViewModels.Dish;

namespace DRRestaurant.Core.Application.ViewModels.Order
{
    public class OrderVM
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public List<DishForOrderVM> DishesSelected { get; set; } = null!;
        public double SubTotal { get; set; }
        public bool IsCompleted { get; set; } 
    }
}
