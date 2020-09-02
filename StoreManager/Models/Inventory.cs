using System;
using System.Collections.Generic;

namespace StoreManager.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            Items = new HashSet<Items>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public float cost { get; set; }
        public float Price { get; set; }
        public int? Quantity { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Items> Items { get; set; }
    }
}
