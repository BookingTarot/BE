using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs.Response
{
    public class BookingResponse
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int TarotReaderId { get; set; }
        public int TarotUserId { get; set; }
        public int ScheduleId { get; set; }
        public int SessionTypeId { get; set; }
        public string TarotReaderName { get; set; }
        public string CustomerName { get; set; }
        public int Age { get; set; }
        public bool? Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string SessionTypeName { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
