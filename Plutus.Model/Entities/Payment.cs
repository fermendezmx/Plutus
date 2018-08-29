using System.Collections.Generic;

namespace Plutus.Model.Entities
{
    public class Payment
    {
        public Payment()
        {
            Receipt = new HashSet<Receipt>();
        }

        public int PaymentId { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }

        public ICollection<Receipt> Receipt { get; set; }
    }
}
