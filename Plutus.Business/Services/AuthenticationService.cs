using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Plutus.Business.Extensions;
using Plutus.Business.Services.Contracts;
using Plutus.Infrastructure.Shared;
using Plutus.Model.Client;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Plutus.Business.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;

        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Public Methods

        public XHRResponse<_Token> Login(_Credentials data)
        {
            XHRResponse<_Token> result = new XHRResponse<_Token>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri($"https://{_configuration["Auth0:Domain"]}/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "oauth/token"))
                    {
                        var body = new
                        {
                            client_id = _configuration["Auth0:ClientId"],
                            client_secret = _configuration["Auth0:ClientSecret"],
                            grant_type = "password",
                            scope = "openid profile email",
                            username = data.Username,
                            password = data.Password
                        };

                        request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
                        HttpResponseMessage response = client.SendAsync(request).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            result.Data = response.Content.ReadAsAsync<_Token>().Result;
                            result.Succeeded = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Message = "Unable to authenticate user.";
                result.Succeeded = false;
            }

            return result;
        }

        #endregion
    }
}
