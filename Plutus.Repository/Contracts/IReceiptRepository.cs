using Plutus.Model.Entities;
using Plutus.Repository.Base;

namespace Plutus.Repository.Contracts
{
    public interface IReceiptRepository : IRepository<Receipt, int>
    {
        void Load(object entity, string property);
    }
}
