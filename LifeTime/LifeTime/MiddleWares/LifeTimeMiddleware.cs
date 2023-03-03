using DependencyInjectionLifeTime.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DependencyInjectionLifeTime.MiddleWares
{
    public class LifeTimeMiddleware
    {
        private readonly RequestDelegate _next;

        public LifeTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext , ScopedService scopedService , TransientService transientService , SingletonService singletonService)
        {
            httpContext.Items.Add("TransientService", "Transient Guid From Middleware = " + transientService.GetGuid());
            httpContext.Items.Add("ScopedService", "Scoped Guid From Middleware = " + scopedService.GetGuid());
            httpContext.Items.Add("SingletoneService", "Singletone Guid From Middleware = " + singletonService.GetGuid());

            await _next(httpContext);
        }
    }
}
