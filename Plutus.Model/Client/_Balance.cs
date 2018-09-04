using System.Collections.Generic;
using System.Linq;

namespace Plutus.Model.Client
{
    public class _Balance
    {
        public _Balance()
        {
            Summary = new List<_DateSummary>();
        }

        public decimal Income
        {
            get
            {
                return Summary.Sum(x => x.Deposit);
            }
        }

        public decimal Expense
        {
            get
            {
                return Summary.Sum(x => x.Withdrawal);
            }
        }

        public decimal Balance
        {
            get
            {
                return Income - Expense;
            }
        }

        public List<_DateSummary> Summary { get; set; }
    }
}
