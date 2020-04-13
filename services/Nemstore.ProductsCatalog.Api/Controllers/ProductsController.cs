using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace NemStore.Api.Controllers
{
    [Route("api/v{version:apiVersion}/products")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IHostEnvironment _environment;

        public ProductsController(IHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet(Name = "GetAllProducts")]
        public IActionResult GetAllProducts() 
        {
            var products = new List<object>
            {
                new { Id= 1, Name = "Iron Maiden T-shirt", Price = "$29.99", ImageUrl = "https://www.emp-shop.dk/dw/image/v2/BBQV_PRD/on/demandware.static/-/Sites-master-emp/default/dw514d8d18/images/4/6/2/3/462389a.jpg?sw=1000&sh=800&sm=fit&sfrm=png" },
                new { Id= 2, Name = "Metallica T-shirt", Price = "$29.99", ImageUrl = "https://www.emp-shop.dk/dw/image/v2/BBQV_PRD/on/demandware.static/-/Sites-master-emp/default/dw6225296d/images/4/4/6/6/446692a.jpg?sw=1000&sh=800&sm=fit&sfrm=png" },
                new { Id= 3, Name = "Children Of Bodom T-shirt", Price = "$29.99", ImageUrl = "https://www.emp-shop.dk/dw/image/v2/BBQV_PRD/on/demandware.static/-/Sites-master-emp/default/dw8edb70ee/images/2/4/7/1/247155a.jpg?sw=1000&sh=800&sm=fit&sfrm=png" }
            };

            if (_environment.IsStaging()) 
            {
                products.Add(new { Id = 4, Name = "Amon Amarth T-shirt", Price = "$29.99", ImageUrl = "https://www.emp-shop.dk/dw/image/v2/BBQV_PRD/on/demandware.static/-/Sites-master-emp/default/dwfa2bcdc6/images/3/2/5/8/325836a-emp.jpg?sw=1000&sh=800&sm=fit&sfrm=png" });
            }

            if (_environment.IsProduction())
            {
                products.Add(new { Id = 4, Name = "Motörhead T-shirt", Price = "$29.99", ImageUrl = "https://www.emp-shop.dk/dw/image/v2/BBQV_PRD/on/demandware.static/-/Sites-master-emp/default/dw06fc718b/images/1/0/3/1/103156a-emp.jpg?sw=1000&sh=800&sm=fit&sfrm=png" });
            }

            return Ok(products);
        }
    }
}
