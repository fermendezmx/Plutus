using System;

namespace Plutus.Model.Entities
{
    public class Receipt
    {
        public int ReceiptId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public int PaymentId { get; set; }
        public string Description { get; set; }
        public string AccountId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Account Account { get; set; }
        public Category Category { get; set; }
        public Payment Payment { get; set; }
    }
}
