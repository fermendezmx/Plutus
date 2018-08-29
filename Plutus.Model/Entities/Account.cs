using System;
using System.Collections.Generic;

namespace Plutus.Model.Entities
{
    public class Account
    {
        public Account()
        {
            Receipt = new HashSet<Receipt>();
        }

        public string AccountId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<Receipt> Receipt { get; set; }
    }
}
