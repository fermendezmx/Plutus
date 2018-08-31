using Microsoft.EntityFrameworkCore;
using Plutus.Context;
using Plutus.Model.Entities;
using Plutus.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public List<Receipt> GetAll(Expression<Func<Receipt, bool>> filter)
        {
            return _context.Receipts
                .Include(x => x.Category)
                .Include(x => x.Payment)
                .Where(filter)
                .OrderBy(x => x.CreatedDate)
                .ToList();
        }

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
