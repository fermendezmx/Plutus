using Plutus.Model.Client;

namespace Plutus.Business.Services.Contracts
{
    public interface IAccountService
    {
        _Account Read(string id);
    }
}
