using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        public async Task<IActionResult> Get() 
        {
            var serviceaIp = Dns.GetHostEntry("servicea.k8s-playground.svc.cluster.local");
            var httpClient = new HttpClient();
            var url = $"http://{serviceaIp.AddressList.FirstOrDefault().ToString()}:6001";
            var serviceaApiCallResponse = await httpClient.GetStringAsync(url);

            var result = $"Response from {serviceaApiCallResponse} received.";

            return Ok(result);
        }
    }
}
