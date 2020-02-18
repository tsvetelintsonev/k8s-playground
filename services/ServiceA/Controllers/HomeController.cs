using Microsoft.AspNetCore.Mvc;
using System;

namespace ServiceA.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        public IActionResult Get() 
        {
            return Ok("ServiceA");
        }
    }
}