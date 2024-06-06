using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs.Request
{
    public class ScheduleRequest
    {
        public int ScheduleId { get; set; }
        public int TarotReaderId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int CustomerId { get; set; }
        public bool? Status { get; set; }
    }
}
