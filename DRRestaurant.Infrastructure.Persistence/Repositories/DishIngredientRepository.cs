using DRRestaurant.Core.Application.Interfaces.Repositories;
using DRRestaurant.Core.Domain.Entities;
using DRRestaurant.Infrastructure.Identity.Context;
using Microsoft.EntityFrameworkCore;

namespace DRRestaurant.Infrastructure.Persistence.Repositories
{
    public class DishIngredientRepository : GenericRepository<DishIngredients>, IDishIngredientRepository
    {
        private readonly RestaurantContext _context;
        public DishIngredientRepository(RestaurantContext restaurantContext) : base(restaurantContext)
        {
            _context = restaurantContext;
        }

        public void DeleteByDishId(int DishId)
        {
           var list = _context.DishIngredients.Where(x => x.DishId == DishId).ToList();

            foreach(var dishIngredient in list)
            {
               _context.Remove(dishIngredient);
                _context.SaveChanges();
            }
        }

        public override async Task<List<DishIngredients>> GetAllWithInclude(List<string> properties)
        {
            var query = _context.Set<DishIngredients>().AsQueryable();

            foreach (var property in properties)
            {
                query = query.Include(property); 
            }

            return await query.ToListAsync();
        }

    }
}
