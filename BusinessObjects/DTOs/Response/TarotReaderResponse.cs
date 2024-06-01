using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs.Response
{
    public class TarotReaderResponse
    {
        public int TarotReaderId { get; set; }
        public string FullName { get; set; }
        public string? Introduction { get; set; }
        public string? Description { get; set; }
        public string? Experience { get; set; }
        public string? Kind { get; set; }
        public byte[]? Image { get; set; }
        public bool? Status { get; set; }
        public List<Schedule> Schedules { get; set; }
       
        public List<SessionType> SessionTypes { get; set; }


    }
}
