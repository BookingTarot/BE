using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
            Feedbacks = new HashSet<Feedback>();
        }

        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
