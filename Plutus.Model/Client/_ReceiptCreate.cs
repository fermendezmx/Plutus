using System;

namespace Plutus.Model.Client
{
    public class _ReceiptCreate
    {
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; } = 0.0M;
        public int CategoryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int PaymentId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
