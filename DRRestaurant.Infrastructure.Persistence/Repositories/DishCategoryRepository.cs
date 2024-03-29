using DRRestaurant.Core.Application.Interfaces.Repositories;
using DRRestaurant.Core.Domain.Entities;
using DRRestaurant.Infrastructure.Identity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRestaurant.Infrastructure.Persistence.Repositories
{
    public class DishCategoryRepository : GenericRepository<DishCategory>, IDishCategoryRepository
    {
        public DishCategoryRepository(RestaurantContext restaurantContext) : base(restaurantContext)
        {
        }
    }
}
