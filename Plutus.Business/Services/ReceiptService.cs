using AutoMapper;
using Plutus.Business.Services.Contracts;
using Plutus.Model.Client;
using Plutus.Model.Entities;
using Plutus.Repository.Contracts;
using System;
using System.Collections.Generic;

namespace Plutus.Business.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository _receiptRepository;

        public ReceiptService(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public _Receipt Create(string userId, _ReceiptLight data)
        {
            _Receipt result = new _Receipt();

            try
            {
                Receipt receipt = Mapper.Map<Receipt>(data);
                receipt.AccountId = userId;
                receipt.CreatedDate = DateTime.Now;
                receipt.ModifiedDate = DateTime.Now;

                _receiptRepository.Insert(receipt);
                _receiptRepository.Save();

                _receiptRepository.Load(receipt, nameof(Category));
                _receiptRepository.Load(receipt, nameof(Payment));

                result = Mapper.Map<_Receipt>(receipt);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to create receipt.");
            }

            return result;
        }

        public List<_Receipt> ReadAllByDate(string userId, DateTime date)
        {
            List<_Receipt> result = new List<_Receipt>();

            try
            {
                List<Receipt> receipts = _receiptRepository.GetAll(x => x.AccountId == userId && date.Date == x.Date.Date);
                result = Mapper.Map<List<_Receipt>>(receipts);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get receipts.");
            }

            return result;
        }
    }
}
