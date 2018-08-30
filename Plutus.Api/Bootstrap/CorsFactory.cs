using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Plutus.Api.Bootstrap
{
    public static class CorsFactory
    {
        public static void AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("AllowAll",
                builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                }));
        }

        public static void UseCors(this IApplicationBuilder app)
        {
            app.UseCors("AllowAll");
        }
    }
}
