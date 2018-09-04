using Plutus.Infrastructure.Shared;
using Plutus.Model.Client;
using System.Collections.Generic;

namespace Plutus.Business.Services.Contracts
{
    public interface IPaymentService
    {
        XHRResponse<List<_Payment>> ReadAll();
    }
}
