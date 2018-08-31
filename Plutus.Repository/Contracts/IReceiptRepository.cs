using Plutus.Model.Entities;
using Plutus.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Plutus.Repository.Contracts
{
    public interface IReceiptRepository : IRepository<Receipt, int>
    {
        List<Receipt> GetAll(Expression<Func<Receipt, bool>> filter);
        void Load(object entity, string property);
    }
}
