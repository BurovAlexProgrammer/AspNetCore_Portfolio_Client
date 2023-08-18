using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AspNetCore_Portfolio.Middlewares
{
    public class SimpleMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync($"Simple middleware");
            await next.Invoke(context);
        }
    }

    public static partial class MiddleExtension
    {
        public static IApplicationBuilder UseSimpleMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SimpleMiddleware>();
        }
    }
}