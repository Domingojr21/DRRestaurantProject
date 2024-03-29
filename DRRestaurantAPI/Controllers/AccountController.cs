using DRRestaurant.Core.Application.Dtos.Account;
using DRRestaurant.Core.Application.Enums;
using DRRestaurant.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DRRestaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _accountService.AuthenticateAsync(request));
        }

        [HttpPost("register-Waiter")]
        public async Task<IActionResult> RegisterWaiterAsync(RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.RegisterUserAsync(request, origin, Roles.Waiter.ToString()));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("register-Admin")]
        public async Task<IActionResult> RegisterAdminAsync(RegisterRequest request)
        {
         
            var origin = Request.Headers["origin"];
          return Ok(await _accountService.RegisterUserAsync(request, origin, Roles.Admin.ToString()));
        }






    }
}
