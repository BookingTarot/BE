using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs.Request
{
    public class GetListBookingRequest
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int TarotReaderId { get; set; }
        public int ScheduleId { get; set; }
        public int SessionTypeId { get; set; }
    }
}
