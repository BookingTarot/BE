using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs.Request
{
    public class SessionTypeRequest
    {
        public int SessionTypeId { get; set; }
        public string? Name { get; set; }
        public int? Duration { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public bool? Status { get; set; }
    }
}
