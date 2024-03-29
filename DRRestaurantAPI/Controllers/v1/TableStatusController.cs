using DRRestaurant.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DRRestaurantAPI.Controllers.v1
{

    [ApiVersion("1.0")]
    [Authorize(Roles = "Waiter,Admin")]
    public class TableStatusController : BaseApiController
    {
        private readonly ITableStatusServices _tableStatusServices;

        public TableStatusController(ITableStatusServices tableStatusServices)
        {
            _tableStatusServices = tableStatusServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTableStatus()
        {
            try
            {
                var list = await _tableStatusServices.GetAllViewModel();

                if (list.Count > 0)
                {
                    return Ok(list);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }
    }
}
