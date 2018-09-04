using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Plutus.Model.Client
{
    public class _CategorySummary
    {
        public _CategorySummary()
        {
            Receipts = new List<_Receipt>();
        }

        public _Category Category { get; set; }

        public decimal Amount
        {
            get
            {
                return Receipts.Sum(x => x.Amount);
            }
        }

        [JsonIgnore]
        public List<_Receipt> Receipts { get; set; }
    }
}
