using System.Collections.Generic;

namespace Plutus.Model.Entities
{
    public class Category
    {
        public Category()
        {
            Receipt = new HashSet<Receipt>();
        }

        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public int TypeId { get; set; }

        public ICollection<Receipt> Receipt { get; set; }
    }
}
