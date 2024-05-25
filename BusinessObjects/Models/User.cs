using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? Gender { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public bool? IsActive { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual Customer? Customer { get; set; }
        public virtual TarotReader? TarotReader { get; set; }
    }
}
