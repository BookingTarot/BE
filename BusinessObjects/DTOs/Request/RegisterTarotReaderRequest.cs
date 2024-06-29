using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs.Request
{
    public class RegisterTarotReaderRequest
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

        public string? Introduction { get; set; }
        public string? Description { get; set; }
        public string? Experience { get; set; }
        public string? Kind { get; set; }
        public byte[]? Image { get; set; }
        public bool? Status { get; set; }
    }
}
