using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class SessionType
    {
        public int SessionTypeId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public bool? Status { get; set; }
    }
}
