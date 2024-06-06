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
        public bool? Status { get; set; }

        public virtual TarotReader TarotReader { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
