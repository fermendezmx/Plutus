using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plutus.Api.Controllers.Base;
using Plutus.Business.Services.Contracts;
using Plutus.Model.Client;
using System;

namespace Plutus.Api.Controllers
{
    [Authorize]
    [Route("api/Receipt")]
    public class ReceiptController : BaseController
    {
        private readonly IReceiptService _receiptService;

        public ReceiptController(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        #region Endpoints

        [HttpPost]
        public IActionResult Post(_ReceiptCreate data)
        {
            return Ok(_receiptService.Create(UserId, data));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_receiptService.Read(UserId, id));
        }

        [HttpGet]
        [Route("Detail/{date}")]
        public IActionResult GetByDate(DateTime date)
        {
            return Ok(_receiptService.ReadAllByDate(UserId, date));
        }

        [HttpGet]
        [Route("Search/{title}")]
        public IActionResult GetBySearch(string title)
        {
            return Ok(_receiptService.ReadAllBySearch(UserId, title));
        }

        [HttpGet]
        [Route("Analysis/{year}/{month}/{typeId}")]
        public IActionResult GetByType(int year, int month, int typeId)
        {
            return Ok(_receiptService.ReadByTypeForAnalysis(UserId, year, month, typeId));
        }

        [HttpPut]
        public IActionResult Put(_ReceiptUpdate data)
        {
            return Ok(_receiptService.Update(UserId, data));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_receiptService.Delete(UserId, id));
        }

        #endregion
    }
}
