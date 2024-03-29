using DRRestaurant.Core.Application.Interfaces.Services;
using DRRestaurant.Core.Application.ViewModels.Dish;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DRRestaurantAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize(Roles = "Admin")]
    public class DishController : BaseApiController
    {
        private readonly IDishServices _dishServices;

        public DishController(IDishServices dishServices)
        {
            _dishServices = dishServices;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
       
        public async Task<IActionResult> Create(SaveDishVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _dishServices.Add(vm);
                    return StatusCode(StatusCodes.Status201Created);

                }

                return BadRequest();
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
          
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(SaveDishVM vm, int id)
        {
            try
            {
                var dishList = await _dishServices.GetAllViewModel();

                bool dishExists = dishList.Exists(x => x.Id == id);

                if (ModelState.IsValid && dishExists)
                {
                    await _dishServices.Update(vm, id);
                    return Ok(vm);
                }
                return BadRequest();
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
         
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> List()
        {
            try
            {
                var list = await _dishServices.GetAllViewModelWithInclude();
                if (list.Count == 0 || list == null)
                {
                    return NotFound();
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
           
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id) 
        {
            try
            {
                var vm = await _dishServices.GetByIdViewModel(id);
                if (vm == null)
                {
                    return NotFound();
                }
                return Ok(vm);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
           
        }
    }
}
