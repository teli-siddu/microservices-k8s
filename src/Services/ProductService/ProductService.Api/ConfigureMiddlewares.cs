using Microsoft.AspNetCore.Authentication;

namespace ProductService.Api
{
    public static class ConfigureMiddlewares
    {
        public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder app)
        {
           
            return app;
        }
    }
}
