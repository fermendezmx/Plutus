using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Plutus.Api.Bootstrap
{
    public static class SwaggerFactory
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Plutus API",
                    Description = "API from the Accounting & Finance subcategory",
                    Contact = new Contact
                    {
                        Name = "Fernando Méndez",
                        Email = "jmendez@itexico.net"
                    }
                });
            });
        }

        public static void UseSwaggerUX(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Plutus API v1");
            });
        }
    }
}
