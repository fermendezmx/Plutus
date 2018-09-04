using System;

namespace Plutus.Model.Client
{
    public class _Receipt
    {
        public int ReceiptId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public _Category Category { get; set; }
        public _Payment Payment { get; set; }
    }
}
