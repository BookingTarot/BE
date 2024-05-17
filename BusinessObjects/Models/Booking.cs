using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Payments = new HashSet<Payment>();
        }

        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int TarotReaderId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool? Status { get; set; }
        public string? Description { get; set; }
        public int ScheduleId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Schedule Schedule { get; set; } = null!;
        public virtual TarotReader TarotReader { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
