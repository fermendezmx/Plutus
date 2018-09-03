using Plutus.Infrastructure.Shared;
using Plutus.Model.Client;

namespace Plutus.Business.Services.Contracts
{
    public interface IAuthenticationService
    {
        XHRResponse<_Token> Login(_Credentials data);
    }
}
