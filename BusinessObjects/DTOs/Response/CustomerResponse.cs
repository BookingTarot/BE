using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs.Response
{
    public class CustomerResponse
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }
    }
}
