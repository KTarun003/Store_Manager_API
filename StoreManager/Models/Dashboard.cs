using System;
using System.Collections.Generic;

namespace StoreManager.Models
{
    public partial class Dashboard
    {
        public int Id { get; set; }
        public int? TotalItems { get; set; }
        public float? TotalWorth { get; set; }
        public int? TotalBills { get; set; }
        public float? TotalAmount { get; set; }
        public int? MonthlyBills { get; set; }
        public float? MonthlyAmount { get; set; }
    }
}
