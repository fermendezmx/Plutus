using Microsoft.EntityFrameworkCore;
using Plutus.Context;
using Plutus.Model.Entities;
using Plutus.Repository.Contracts;
using System.Linq;

namespace Plutus.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountContext _context;

        public AccountRepository()
        {
            _context = new AccountContext();
        }

        #region Base

        public Account GetById(string id)
        {
            return _context.Accounts.FirstOrDefault(x => x.AccountId == id);
        }

        public void Insert(Account data)
        {
            _context.Entry(data).State = EntityState.Added;
        }

        public void Update(Account data)
        {
            _context.Entry(data).State = EntityState.Modified;
        }

        public void Delete(Account data)
        {
            _context.Entry(data).State = EntityState.Deleted;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        #endregion
    }
}
