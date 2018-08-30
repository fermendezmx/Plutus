using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace Plutus.Api.Bootstrap
{
    public static class MvcFactory
    {
        public static void AddMvcConfiguration(this IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    if (options.SerializerSettings.ContractResolver != null)
                    {
                        var resolver = options.SerializerSettings.ContractResolver as DefaultContractResolver;
                        resolver.NamingStrategy = null;
                    }
                });
        }
    }
}
