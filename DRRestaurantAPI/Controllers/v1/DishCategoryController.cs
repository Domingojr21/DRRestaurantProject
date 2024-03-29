using DRRestaurant.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DRRestaurantAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize(Roles = "Admin")]
    public class DishCategoryController : BaseApiController
    {
        private readonly IDishCategoryServices _services;

        public DishCategoryController(IDishCategoryServices services)
        {
            _services = services;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDishCategories()
        {
            var categoryList = await _services.GetAllViewModel();
            try
            {
                if (categoryList == null)
                {
                    return NotFound();
                }

                return Ok(categoryList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
           
        }
    }
}
