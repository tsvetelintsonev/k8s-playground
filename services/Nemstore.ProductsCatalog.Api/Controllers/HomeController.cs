using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace NemStore.Api.Controllers
{
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet(Name = "GetAllProducts")]
        public IActionResult GetAllProducts() 
        {
            return Ok(new List<object> 
            {
                new { Id= 1, Name = "Iron Maiden T-shirt" },
                new { Id= 2, Name = "Metallica T-shirt" },
                new { Id= 3, Name = "Children Of Bodom T-shirt" }
            });
        }
    }
}
