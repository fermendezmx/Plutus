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

        /// <summary>
        /// Create receipt
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(_ReceiptCreate data)
        {
            return Ok(_receiptService.Create(UserId, data));
        }

        /// <summary>
        /// Get receipt by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_receiptService.Read(UserId, id));
        }

        /// <summary>
        /// Get all receipts for a given date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Detail/{date}")]
        public IActionResult GetByDate(DateTime date)
        {
            return Ok(_receiptService.ReadAllByDate(UserId, date));
        }

        /// <summary>
        /// Get all receipts with a given title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Search/{title}")]
        public IActionResult GetBySearch(string title)
        {
            return Ok(_receiptService.ReadAllBySearch(UserId, title));
        }

        /// <summary>
        /// Get analysis of incomes or expenses by category in a given month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="typeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Analysis/{year}/{month}/{typeId}")]
        public IActionResult GetByType(int year, int month, int typeId)
        {
            return Ok(_receiptService.ReadByTypeForAnalysis(UserId, year, month, typeId));
        }

        /// <summary>
        /// Update receipt
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(_ReceiptUpdate data)
        {
            return Ok(_receiptService.Update(UserId, data));
        }

        /// <summary>
        /// Delete receipt by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_receiptService.Delete(UserId, id));
        }

        #endregion
    }
}
