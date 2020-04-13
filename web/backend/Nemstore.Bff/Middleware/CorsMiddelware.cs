using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nemstore.Bff.Middleware
{
    public class CorsMiddelware : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            context.Response.Headers.Add("Access-Control-Allow-Headers", "Access-Control-Allow-Origin");

            if (context.Request.Method == HttpMethod.Options.Method)
            {
                context.Response.StatusCode = 200;
                return context.Response.WriteAsync("OK");
            }

            return next(context);
        }
    }
}
