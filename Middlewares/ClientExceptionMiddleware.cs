using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AspNetCore_Portfolio.Middlewares
{
    public class ClientExceptionMiddleware : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Response.StatusCode = 400;
            return next.Invoke(context);
        }
    }
}