using DRRestaurant.Core.Application.Interfaces.Repositories;
using DRRestaurant.Core.Application.Interfaces.Services;
using DRRestaurant.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DRRestaurant.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            #region Services
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IGenericService<,,>),typeof(GenericServices<,,>));
            services.AddTransient<IIngredientServices, IngredientServices>();
            services.AddTransient<IDishCategoryServices, DishCategoryServices>();
            services.AddTransient<IDishServices, DishServices>();
            services.AddTransient<IDishIngredientServices, DishIngredienteServices>();
            services.AddTransient<ITableStatusServices, TableStatusServices>();
            services.AddTransient<ITableServices, TablesServices>();
            services.AddTransient<IOrderServices, OrderServices>();
            services.AddTransient<IOrderDishesServices, OrderDishesServices>();
            #endregion
        }
    }
}
