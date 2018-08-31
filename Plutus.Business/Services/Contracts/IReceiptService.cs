using Plutus.Model.Client;

namespace Plutus.Business.Services.Contracts
{
    public interface IReceiptService
    {
        _Receipt Create(string userId, _ReceiptLight data);
    }
}
