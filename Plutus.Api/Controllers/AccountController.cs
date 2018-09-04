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

        #region Endpoints

        /// <summary>
        /// Get profile of current user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_accountService.Read(UserId));
        }

        [HttpGet]
        [Route("Balance/{year}/{month}")]
        public IActionResult GetBalance(int year, int month)
        {
            return Ok(_accountService.ReadBalance(UserId, year, month));
        }

        #endregion
    }
}
