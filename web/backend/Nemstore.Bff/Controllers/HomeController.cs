using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace NemStore.Api.Controllers
{
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private const string PRODUCTSCATALOG_URL_SETTING_KEY = "productsCatalogUrl";

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(Name = "GetAllProducts")]
        public async Task<IActionResult> GetAllProducts() 
        {
            try
            {
                var productsCatalogUrl = _configuration.GetValue<string>(PRODUCTSCATALOG_URL_SETTING_KEY).Trim('/');
                var url = $"http://{productsCatalogUrl}/api/v1.0";
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
