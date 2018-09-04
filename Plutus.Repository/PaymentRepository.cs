using Microsoft.EntityFrameworkCore;
using Plutus.Context;
using Plutus.Model.Entities;
using Plutus.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Plutus.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentContext _context;

        public PaymentRepository()
        {
            _context = new PaymentContext();
        }

        #region Contract

        public List<Payment> GetAll()
        {
            return _context.Payments.ToList();
        }

        #endregion

        #region Base

        public Payment GetById(int id)
        {
            return _context.Payments.FirstOrDefault(x => x.PaymentId == id);
        }

        public void Insert(Payment data)
        {
            _context.Entry(data).State = EntityState.Added;
        }

        public void Update(Payment data)
        {
            _context.Entry(data).State = EntityState.Modified;
        }

        public void Delete(Payment data)
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
