using System.Collections.Generic;
using System.Linq;

namespace Plutus.Model.Client
{
    public class _Analysis
    {
        public _Analysis()
        {
            Summary = new List<_CategorySummary>();
        }

        public decimal Balance
        {
            get
            {
                return Summary.Sum(x => x.Amount);
            }
        }

        public List<_CategorySummary> Summary { get; set; }
    }
}
