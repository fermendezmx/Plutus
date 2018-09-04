using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plutus.Business.Services.Contracts;

namespace Plutus.Api.Controllers
{
    [Authorize]
    [Route("api/Payment")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        #region Endpoints

        [HttpGet]
        [Route("All")]
        public IActionResult Get()
        {
            return Ok(_paymentService.ReadAll());
        }

        #endregion
    }
}
