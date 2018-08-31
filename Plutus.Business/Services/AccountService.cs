using AutoMapper;
using Plutus.Business.Services.Contracts;
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

        public _Account Read(string id)
        {
            _Account result = new _Account();

            try
            {
                Account account = _accountRepository.GetById(id);
                result = Mapper.Map<_Account>(account);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get user.");
            }

            return result;
        }

        #endregion
    }
}
