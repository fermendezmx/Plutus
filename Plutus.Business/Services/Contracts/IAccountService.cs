using Plutus.Infrastructure.Shared;
using Plutus.Model.Client;

namespace Plutus.Business.Services.Contracts
{
    public interface IAccountService
    {
        XHRResponse<_Account> Read(string id);
    }
}
