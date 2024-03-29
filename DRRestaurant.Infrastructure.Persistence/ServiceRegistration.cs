using DRRestaurant.Core.Application.Interfaces.Repositories;
using DRRestaurant.Infrastructure.Identity.Context;
using DRRestaurant.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DRRestaurant.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            #region Context
            bool UseInMemory = configuration.GetValue<bool>("UseInMemoryDatabase");

            if(UseInMemory)
            {
                services.AddDbContext<RestaurantContext>(options => options.UseInMemoryDatabase("DRRestaurant"));
            }else
            {
                var connectionString = configuration.GetConnectionString("RestaurantConnectionString");
                services.AddDbContext<RestaurantContext>(options =>
                options.UseSqlServer(connectionString, opt => opt.MigrationsAssembly(typeof(RestaurantContext).Assembly.FullName)));
            }
            #endregion

            #region Repository
            services.AddTransient<IDishCategoryRepository, DishCategoryRepository>();
            services.AddTransient<IDishRepository, DishRepository>();
            services.AddTransient<IDishIngredientRepository, DishIngredientRepository>();
            services.AddTransient<IIngredientRepository, IngredientRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderDishesRepository, OrderDishesRepository>();
            services.AddTransient<ITableRepository, TableRepository>();
            services.AddTransient<ITableStatusRepository, TableStatusRepository>();
            #endregion

        }
    }
}
