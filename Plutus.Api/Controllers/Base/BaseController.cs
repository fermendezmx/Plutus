using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace Plutus.Api.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        private const string NameIdentifier = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";

        public string UserId
        {
            get
            {
                return (User.Identity as ClaimsIdentity).Claims.FirstOrDefault(claim => claim.Type == NameIdentifier)?.Value;
            }
        }
    }
}
