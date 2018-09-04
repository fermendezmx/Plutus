using Plutus.Model.Entities;
using Plutus.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Plutus.Repository.Contracts
{
    public interface IAccountRepository : IRepository<Account, string>
    {
        List<Receipt> GetReceipts(Expression<Func<Receipt, bool>> filter);
    }
}
