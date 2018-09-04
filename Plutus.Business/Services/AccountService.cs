using AutoMapper;
using Plutus.Business.Common;
using Plutus.Business.Services.Contracts;
using Plutus.Infrastructure.Shared;
using Plutus.Model.Client;
using Plutus.Model.Entities;
using Plutus.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Plutus.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        #region Public Methods

        public XHRResponse<_Account> Read(string userId)
        {
            XHRResponse<_Account> result = new XHRResponse<_Account>();

            try
            {
                Account account = _accountRepository.GetById(userId);
                result.Data = Mapper.Map<_Account>(account);
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.Message = "Unable to get user.";
                result.Succeeded = false;
            }

            return result;
        }

        public XHRResponse<_Balance> ReadBalance(string userId, int year, int month)
        {
            XHRResponse<_Balance> result = new XHRResponse<_Balance>();

            try
            {
                List<Receipt> receipts = _accountRepository.GetReceipts(x => x.AccountId == userId
                    && x.TransactionDate.Month == month
                    && x.TransactionDate.Year == year);

                var groups = from Receipt receipt in receipts
                             group receipt by receipt.TransactionDate.Date
                     into items
                             select new
                             {
                                 Date = items.Key,
                                 Receipts = items
                             };

                foreach(var group in groups)
                {
                    result.Data.Summary.Add(new _DateSummary
                    {
                        Date = group.Date,
                        Deposit = group.Receipts.Where(x => x.Category.TypeId == (int)PlutusCategoryType.Income).Sum(x => x.Amount),
                        Withdrawal = group.Receipts.Where(x => x.Category.TypeId == (int)PlutusCategoryType.Expense).Sum(x => x.Amount)
                    });
                }

                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.Message = "Unable to get balance.";
                result.Succeeded = false;
            }

            return result;
        }

        #endregion
    }
}
