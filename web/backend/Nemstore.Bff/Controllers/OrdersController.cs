using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Nemstore.Bff.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Nemstore.Bff.Controllers
{
    [Route("api/v{version:apiVersion}/orders")]
    [ApiVersion("1.0")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private const string ORDERS_URL_SETTING_KEY = "ordersApiUrl";

        public OrdersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost(Name = "CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            try
            {
                var productsCatalogUrl = _configuration.GetValue<string>(ORDERS_URL_SETTING_KEY).Trim('/');
                var url = $"http://{productsCatalogUrl}/api/v1.0/orders";
                var httpClient = new HttpClient();
                var response = await httpClient.PostAsync(url, new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json"));

                return Ok(await response.Content.ReadAsStringAsync());
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex);
                throw;
            }
        }
    }
}
