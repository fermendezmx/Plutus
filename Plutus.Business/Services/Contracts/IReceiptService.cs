using Plutus.Model.Client;
using System;
using System.Collections.Generic;

namespace Plutus.Business.Services.Contracts
{
    public interface IReceiptService
    {
        _Receipt Create(string userId, _ReceiptCreate data);
        _Receipt Read(string userId, int receiptId);
        List<_Receipt> ReadAllByDate(string userId, DateTime date);
        _Receipt Update(string userId, _ReceiptUpdate data);
    }
}
