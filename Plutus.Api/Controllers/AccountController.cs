using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plutus.Api.Controllers.Base;
using Plutus.Business.Services.Contracts;

namespace Plutus.Api.Controllers
{
    [Authorize]
    [Route("api/Account")]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_accountService.Read(UserId));
        }
    }
}
