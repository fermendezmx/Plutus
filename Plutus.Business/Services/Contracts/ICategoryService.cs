using Plutus.Infrastructure.Shared;
using Plutus.Model.Client;
using System.Collections.Generic;

namespace Plutus.Business.Services.Contracts
{
    public interface ICategoryService
    {
        XHRResponse<List<_Category>> ReadAllByType(int typeId);
    }
}
