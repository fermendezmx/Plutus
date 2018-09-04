using Plutus.Model.Entities;
using Plutus.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Plutus.Repository.Contracts
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        List<Category> GetAll(Expression<Func<Category, bool>> filter);
    }
}
