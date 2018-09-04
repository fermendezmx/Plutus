using AutoMapper;
using Plutus.Business.Services.Contracts;
using Plutus.Infrastructure.Shared;
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

        #region Public Methods

        public XHRResponse<_Receipt> Create(string userId, _ReceiptCreate data)
        {
            XHRResponse<_Receipt> result = new XHRResponse<_Receipt>();

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

                result.Data = Mapper.Map<_Receipt>(receipt);
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.Message = "Unable to create receipt.";
                result.Succeeded = false;
            }

            return result;
        }

        public XHRResponse<_Receipt> Read(string userId, int receiptId)
        {
            XHRResponse<_Receipt> result = new XHRResponse<_Receipt>();

            try
            {
                Receipt receipt = _receiptRepository.GetById(receiptId, userId);
                ThrowExceptionIfReceiptDoesntExists(receipt);

                result.Data = Mapper.Map<_Receipt>(receipt);
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.Message = "Unable to get receipt.";
                result.Succeeded = false;
            }

            return result;
        }

        public XHRResponse<List<_Receipt>> ReadAllByDate(string userId, DateTime date)
        {
            XHRResponse<List<_Receipt>> result = new XHRResponse<List<_Receipt>>();

            try
            {
                List<Receipt> receipts = _receiptRepository.GetAll(x => x.AccountId == userId && date.Date == x.TransactionDate.Date);
                result.Data = Mapper.Map<List<_Receipt>>(receipts);
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.Message = "Unable to get receipts.";
                result.Succeeded = false;
            }

            return result;
        }

        public XHRResponse<List<_Receipt>> ReadAllBySearch(string userId, string title)
        {
            XHRResponse<List<_Receipt>> result = new XHRResponse<List<_Receipt>>();

            try
            {
                List<Receipt> receipts = _receiptRepository.GetAll(x => x.AccountId == userId && x.Title.Contains(title));
                result.Data = Mapper.Map<List<_Receipt>>(receipts);
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.Message = "Unable to get receipts.";
                result.Succeeded = false;
            }

            return result;
        }

        public XHRResponse<_Receipt> Update(string userId, _ReceiptUpdate data)
        {
            XHRResponse<_Receipt> result = new XHRResponse<_Receipt>();

            try
            {
                Receipt receipt = _receiptRepository.GetById(data.ReceiptId);
                ThrowExceptionIfIsInvalidReceipt(receipt, userId);

                receipt.TransactionDate = data.TransactionDate;
                receipt.Amount = data.Amount;
                receipt.CategoryId = data.CategoryId;
                receipt.Title = data.Title;
                receipt.PaymentId = data.PaymentId;
                receipt.Description = data.Description;

                _receiptRepository.Update(receipt);
                _receiptRepository.Save();

                _receiptRepository.Load(receipt, nameof(Category));
                _receiptRepository.Load(receipt, nameof(Payment));

                result.Data = Mapper.Map<_Receipt>(receipt);
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.Message = "Unable to update receipt.";
                result.Succeeded = false;
            }

            return result;
        }

        public XHRResponse<bool> Delete(string userId, int receiptId)
        {
            XHRResponse<bool> result = new XHRResponse<bool>();

            try
            {
                Receipt receipt = _receiptRepository.GetById(receiptId, userId);
                ThrowExceptionIfReceiptDoesntExists(receipt);

                _receiptRepository.Delete(receipt);
                _receiptRepository.Save();

                result.Data = true;
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.Message = "Unable to delete receipt.";
                result.Succeeded = false;
            }

            return result;
        }

        #endregion

        #region Private Methods

        private void ThrowExceptionIfReceiptDoesntExists(Receipt receipt)
        {
            if (receipt == null)
            {
                throw new Exception("Receipt doesn't exists.");
            }
        }

        private void ThrowExceptionIfIsInvalidReceipt(Receipt receipt, string userId)
        {
            if (receipt == null || receipt.AccountId != userId)
            {
                throw new Exception("Invalid receipt.");
            }
        }

        #endregion
    }
}
