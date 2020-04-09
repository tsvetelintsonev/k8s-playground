using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace NemStore.Api.Controllers
{
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet(Name = "GetAllProducts")]
        public async Task<IActionResult> GetAllProducts() 
        {
            try
            {
                var url = $"http://nemstore-productscatalog.nemstore.svc.cluster.local/api/v1.0";
                var httpClient = new HttpClient();
                var products = await httpClient.GetStringAsync(url);

                return Ok(products);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex);
                throw;
            }
        }
    }
}
