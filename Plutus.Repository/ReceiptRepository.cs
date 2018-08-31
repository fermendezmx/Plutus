using Microsoft.EntityFrameworkCore;
using Plutus.Context;
using Plutus.Model.Entities;
using Plutus.Repository.Contracts;
using System.Linq;

namespace Plutus.Repository
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly ReceiptContext _context;

        public ReceiptRepository()
        {
            _context = new ReceiptContext();
        }

        #region Contract

        public void Load(object entity, string property)
        {
            _context.Entry(entity).Reference(property).Load();
        }

        #endregion

        #region Base

        public Receipt GetById(int id)
        {
            return _context.Receipts.FirstOrDefault(x => x.ReceiptId == id);
        }

        public void Insert(Receipt data)
        {
            _context.Entry(data).State = EntityState.Added;
        }

        public void Update(Receipt data)
        {
            _context.Entry(data).State = EntityState.Modified;
        }

        public void Delete(Receipt data)
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
