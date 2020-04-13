using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Nemstore.Orders.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Nemstore.Orders.Api.Controllers
{
    [Route("api/v{version:apiVersion}/orders")]
    [ApiVersion("1.0")]
    [ApiController]
    public class OrdersControllers : ControllerBase
    {
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;
        private const string PRODUCTSCATALOG_URL_SETTING_KEY = "productsCatalogUrl";
        private const string ORDERS_CACHE_KEY = "orders";

        public OrdersControllers(IConfiguration configuration, IMemoryCache cache)
        {
            _configuration = configuration;
            _cache = cache;
        }

        [HttpGet(Name = "GetAllOrders")]
        public IActionResult GetAllOrders() 
        {
            return Ok(_cache.Get(ORDERS_CACHE_KEY));
        }

        [HttpPost(Name = "CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request) 
        {
            try
            {
                var productsCatalogUrl = _configuration.GetValue<string>(PRODUCTSCATALOG_URL_SETTING_KEY).Trim('/');
                var url = $"http://{productsCatalogUrl}/api/v1.0/products";
                var httpClient = new HttpClient();
                var products = JsonSerializer.Deserialize<IEnumerable<Product>>(await httpClient.GetStringAsync(url),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    });

                var order = new Order();
                order.Id = Guid.NewGuid();
                order.Lines = new List<OrderLine>();

                foreach (var line in request.Lines)
                {
                    var product = products.Single(x => x.Id == line.ProductId);
                    var unitPrice = Convert.ToDecimal(((string)product.Price).Substring(1));

                    var orderLine = new OrderLine
                    {
                        Id = Guid.NewGuid(),
                        ProductId = product.Id,
                        ProductName = product.Name,
                        ProductImageUrl = product.ImageUrl,
                        UnitPrice = unitPrice,
                        OrderId = order.Id,
                        Quantity = line.Quantity,
                        TotalPrice = unitPrice * line.Quantity
                    };

                    order.Lines.Add(orderLine);
                }

                var orders = _cache.GetOrCreate<IList<Order>>(ORDERS_CACHE_KEY, _ => new List<Order>());

                orders.Add(order);

                _cache.Set(ORDERS_CACHE_KEY, orders);

                return Ok(order.Id);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex);
                throw;
            }
        }
    }
}
