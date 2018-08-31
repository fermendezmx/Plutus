using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plutus.Api.Controllers.Base;
using Plutus.Business.Services.Contracts;
using Plutus.Model.Client;

namespace Plutus.Api.Controllers
{
    [Authorize]
    [Route("api/receipt")]
    public class ReceiptController : BaseController
    {
        private readonly IReceiptService _receiptService;

        public ReceiptController(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        [HttpPost]
        public IActionResult Post(_ReceiptLight data)
        {
            return Ok(_receiptService.Create(UserId, data));
        }
    }
}
