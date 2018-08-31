using AutoMapper;
using Plutus.Business.Services.Contracts;
using Plutus.Infrastructure.Shared;
using Plutus.Model.Client;
using Plutus.Model.Entities;
using Plutus.Repository.Contracts;
using System;

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

        public XHRResponse<_Account> Read(string id)
        {
            XHRResponse<_Account> result = new XHRResponse<_Account>();

            try
            {
                Account account = _accountRepository.GetById(id);
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

        #endregion
    }
}
