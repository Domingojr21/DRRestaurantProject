using DRRestaurant.Core.Application.Interfaces.Repositories;
using DRRestaurant.Core.Application.Interfaces.Services;
using DRRestaurantAPI.Controllers.v1;
using Microsoft.AspNetCore.Mvc;

namespace Prueba
{
    public class UnitTest1
    {
        private readonly IDishServices _services;

        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public void Test_Index_GetAll_Count()
        {
            var controller = new DishController(_services);
            var result = controller.List();

            //var quantity = 5;

            var hopeResult = Assert.IsType<Task<IActionResult>>(result);
        }
    }
}