using Microsoft.AspNetCore.Mvc;

namespace ServiceC.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        public IActionResult Get() 
        {
            return Ok("ServiceC");
        }
    }
}