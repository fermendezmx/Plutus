using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System.Threading;

namespace Plutus.Api.Bootstrap
{
    public static class AuthenticationFactory
    {
        private static readonly string Domain = $"https://{Startup.Configuration["Auth0:Domain"]}/";
        private static readonly string ClientId = Startup.Configuration["Auth0:ClientId"];

        public static void AddJwtAuthentication(this IServiceCollection services)
        {
            var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>($"{Domain}.well-known/openid-configuration", new OpenIdConnectConfigurationRetriever());
            var openIdConfig = configurationManager.GetConfigurationAsync(CancellationToken.None).Result;

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Domain,
                        ValidAudience = ClientId,
                        IssuerSigningKeyResolver = (token, securityToken, identifier, parameters) => openIdConfig.SigningKeys
                    };
                });
        }
    }
}
