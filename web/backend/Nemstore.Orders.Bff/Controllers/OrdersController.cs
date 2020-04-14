using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
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

        [HttpGet(Name = "GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var ordersApiUrl = _configuration.GetValue<string>(ORDERS_URL_SETTING_KEY).Trim('/');
            var url = $"http://{ordersApiUrl}/api/v1.0/orders";
            var httpClient = new HttpClient();
            var orders = await httpClient.GetStringAsync(url);

            return Ok(orders);
        }
    }
}
