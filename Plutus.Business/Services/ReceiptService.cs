﻿using AutoMapper;
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

        #region Public Methods

        public _Receipt Create(string userId, _ReceiptCreate data)
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

        public _Receipt Read(string userId, int receiptId)
        {
            _Receipt result = new _Receipt();

            try
            {
                Receipt receipt = _receiptRepository.GetById(receiptId, userId);
                ThrowExceptionIfReceiptDoesntExists(receipt);
                result = Mapper.Map<_Receipt>(receipt);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get receipt.");
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

        public _Receipt Update(string userId, _ReceiptUpdate data)
        {
            _Receipt result = new _Receipt();

            try
            {
                Receipt receipt = _receiptRepository.GetById(data.ReceiptId);
                ThrowExceptionIfIsInvalidReceipt(receipt, userId);

                receipt.Date = data.Date;
                receipt.Amount = data.Amount;
                receipt.CategoryId = data.CategoryId;
                receipt.Title = data.Title;
                receipt.PaymentId = data.PaymentId;
                receipt.Description = data.Description;

                _receiptRepository.Update(receipt);
                _receiptRepository.Save();

                _receiptRepository.Load(receipt, nameof(Category));
                _receiptRepository.Load(receipt, nameof(Payment));

                result = Mapper.Map<_Receipt>(receipt);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to update receipt.");
            }

            return result;
        }

        public void Delete(string userId, int receiptId)
        {
            try
            {
                Receipt receipt = _receiptRepository.GetById(receiptId, userId);
                ThrowExceptionIfReceiptDoesntExists(receipt);
                _receiptRepository.Delete(receipt);
                _receiptRepository.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to delete receipt.");
            }
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
