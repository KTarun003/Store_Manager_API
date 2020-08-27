using System;
using System.Collections.Generic;

namespace StoreManager.Models
{
    public partial class ItemsCost
    {
        public string Id { get; set; }
        public float? Cost { get; set; }

        public virtual Inventory IdNavigation { get; set; }
    }
}
