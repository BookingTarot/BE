using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Bill
    {
        public int BillId { get; set; }
        public int PaymentId { get; set; }
        public DateTime? BillingDate { get; set; }
        public int? TotalAmount { get; set; }

        public virtual Payment Payment { get; set; } = null!;
    }
}
