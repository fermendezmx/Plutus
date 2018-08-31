using Plutus.Model.Client;
using System;
using System.Collections.Generic;

namespace Plutus.Business.Services.Contracts
{
    public interface IReceiptService
    {
        _Receipt Create(string userId, _ReceiptLight data);
        List<_Receipt> ReadAllByDate(string userId, DateTime date);
    }
}
