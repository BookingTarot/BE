using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs.Request
{
    public class BookingWithScheduleRequest
    {

        public int CustomerId { get; set; }
        public int TarotReaderId { get; set; }
        public double? Amount { get; set; }
        public string? Description { get; set; }
        public int SessionTypeId { get; set; }


        public DateTime? BookDate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

    }
}
