using Plutus.Infrastructure.Shared;
using Plutus.Model.Client;
using System;
using System.Collections.Generic;

namespace Plutus.Business.Services.Contracts
{
    public interface IReceiptService
    {
        XHRResponse<_Receipt> Create(string userId, _ReceiptCreate data);
        XHRResponse<_Receipt> Read(string userId, int receiptId);
        XHRResponse<List<_Receipt>> ReadAllByDate(string userId, DateTime date);
        XHRResponse<List<_Receipt>> ReadAllBySearch(string userId, string title);
        XHRResponse<_Receipt> Update(string userId, _ReceiptUpdate data);
        XHRResponse<bool> Delete(string userId, int receiptId);
    }
}
