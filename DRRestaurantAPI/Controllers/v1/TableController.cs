using DRRestaurant.Core.Application.Interfaces.Services;
using DRRestaurant.Core.Application.Services;
using DRRestaurant.Core.Application.ViewModels.Table;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DRRestaurantAPI.Controllers.v1
{
    [ApiVersion("1.0")]  
    public class TableController : BaseApiController
    {
        private readonly ITableServices _tableServices;
        private readonly ITableStatusServices _tableStatusServices;
        private readonly IOrderServices _orderServices;

        public TableController(ITableServices tableServices, ITableStatusServices tableStatusServices, IOrderServices orderServices)
        {
            _tableServices = tableServices;
            _tableStatusServices = tableStatusServices;
            _orderServices = orderServices;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(SaveTableVM svm)
        {
            try
            {
                var tableStatusList = await _tableStatusServices.GetAllViewModel();

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                bool tableStatusExists = tableStatusList.Exists(x => x.Id == svm.TableStatusId);

                if (tableStatusExists)
                {
                    await _tableServices.Add(svm);
                    return NoContent();
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex);
            }
           
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "Waiter,Admin")]
        public async Task<IActionResult> List()
        {
            try
            {
                var list = await _tableServices.GetAllVM();

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



            [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(SaveTableVM svm, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                svm.Id = id;
                await _tableServices.Update(svm, id);

                return Ok(svm);
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
        [Authorize(Roles = "Waiter,Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var table = await _tableServices.GetTableById(id);

                if (table != null)
                {
                    return Ok(table);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex);
            }
           
        }

        [HttpGet("GetOrder'sTable{tableId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Waiter")]
        public async Task<IActionResult> GetOrdersTableId(int tableId)
        {
            try
            {
                var orderList = await _orderServices.GetOrdersByTableId(tableId);

                if (orderList != null && orderList.Count > 1)
                {
                    return Ok(orderList);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }

        [HttpPatch("ChangeStatus{tableId},{tableStatusId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Waiter")]
        public async Task<IActionResult> ChangeStatus(int tableId, int tableStatusId)
        {
           try
            {
                await _tableServices.ChangeStatus(tableId, tableStatusId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
           
        }
    }
}
