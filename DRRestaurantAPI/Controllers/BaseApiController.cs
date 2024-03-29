using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DRRestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {

    }
}
