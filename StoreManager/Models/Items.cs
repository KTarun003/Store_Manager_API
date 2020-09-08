using System;
using System.Collections.Generic;

namespace StoreManager.Models
{
    public partial class Items
    {
        public string ItemId { get; set; }
        public string BillId { get; set; }
        public int Quantity { get; set; }

        public virtual Bills Bill { get; set; }
        public virtual Inventory Item { get; set; }
    }
}
