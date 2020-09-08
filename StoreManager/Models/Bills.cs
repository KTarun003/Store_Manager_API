using System;
using System.Collections.Generic;

namespace StoreManager.Models
{
    public partial class Bills
    {
        public Bills()
        {
            Items = new HashSet<Items>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public float? Amount { get; set; }
        public int? Quantity { get; set; }
        public string Location { get; set; }
        public DateTime? BillDate { get; set; }

        public virtual ICollection<Items> Items { get; set; }
    }
}
