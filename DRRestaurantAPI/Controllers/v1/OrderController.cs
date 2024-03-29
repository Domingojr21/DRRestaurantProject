using DRRestaurant.Core.Application.Interfaces.Services;
using DRRestaurant.Core.Application.ViewModels.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DRRestaurantAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize(Roles = "Waiter")]
    public class OrderController : BaseApiController
    {
        private readonly IOrderServices _orderServices;


        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(SaveOrderVM svm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _orderServices.Add(svm);
                return StatusCode(StatusCodes.Status201Created);
            } catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
           
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(UpdateOrderViewModel updateOrder, int Id)
        {
            try
            {
                var list = await _orderServices.GetAllViewModel();

                bool orderExists = list.Exists(x => x.Id == Id);

                if (orderExists && ModelState.IsValid)
                {
                    await _orderServices.UpdateOrderDish(updateOrder, Id);
                    return NoContent();
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> List()
        {
            try
            {
                var list = await _orderServices.GetAllVMWithInclude();

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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var table = await _orderServices.GetByOrderIdVM(id);

                if (table != null)
                {
                    return Ok(table);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }

        [HttpPatch("Delete{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _orderServices.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex);
            }
          
        }


        [HttpPatch("ChangeStatusToIsCompleted{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ChangeStatusToIsCompleted(int id)
        {
            try
            {
                await _orderServices.ChangeStatusToIsCompleted(id);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
           
        }




    }
}
