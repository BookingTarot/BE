using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            Bookings = new HashSet<Booking>();
        }

        public int ScheduleId { get; set; }
        public int TarotReaderId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual TarotReader TarotReader { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
