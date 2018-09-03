using Microsoft.AspNetCore.Mvc;
using Plutus.Api.Controllers.Base;
using Plutus.Business.Services.Contracts;
using Plutus.Model.Client;

namespace Plutus.Api.Controllers
{
    [Route("api/Authentication")]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        #region Endpoints

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(_Credentials data)
        {
            return Ok(_authenticationService.Login(data));
        }

        #endregion
    }
}
