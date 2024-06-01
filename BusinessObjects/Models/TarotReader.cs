using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class TarotReader
    {
        public TarotReader()
        {
            Bookings = new HashSet<Booking>();
            Feedbacks = new HashSet<Feedback>();
            Schedules = new HashSet<Schedule>();
            SessionTypes = new HashSet<SessionType>();
        }

        public int TarotReaderId { get; set; }
        public int UserId { get; set; }
        public string? Introduction { get; set; }
        public string? Description { get; set; }
        public string? Experience { get; set; }
        public string? Kind { get; set; }
        public byte[]? Image { get; set; }
        public bool? Status { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }

        public virtual ICollection<SessionType> SessionTypes { get; set; }
    }
}
