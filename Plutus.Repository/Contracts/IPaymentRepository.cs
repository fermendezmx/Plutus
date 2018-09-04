using Plutus.Model.Entities;
using Plutus.Repository.Base;
using System.Collections.Generic;

namespace Plutus.Repository.Contracts
{
    public interface IPaymentRepository : IRepository<Payment, int>
    {
        List<Payment> GetAll();
    }
}
