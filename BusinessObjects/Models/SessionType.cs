using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class SessionType
    {
        public SessionType()
        {
            Bookings = new HashSet<Booking>();
            TarotReaders = new HashSet<TarotReader>();
        }

        public int SessionTypeId { get; set; }
        public string? Name { get; set; }
        public int? Duration { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual ICollection<TarotReader> TarotReaders { get; set; }
    }
}
