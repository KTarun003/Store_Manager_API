using System;
using System.Collections.Generic;

namespace StoreManager.Models
{
    public partial class Items
    {
        public string ItemId { get; set; }
        public int BillId { get; set; }

        public virtual Bills Bill { get; set; }
        public virtual Inventory Item { get; set; }
    }
}
