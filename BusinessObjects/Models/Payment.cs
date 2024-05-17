using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Bills = new HashSet<Bill>();
        }

        public int PaymentId { get; set; }
        public int BookingId { get; set; }
        public int? Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? PaymentMethod { get; set; }
        public bool? Status { get; set; }

        public virtual Booking Booking { get; set; } = null!;
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
