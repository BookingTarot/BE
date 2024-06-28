using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs.Request
{
    public class TarotReaderRequest
    {
        public int TarotReaderId { get; set; }
        public int UserId { get; set; }
        public string? Introduction { get; set; }
        public string? Description { get; set; }
        public string? Experience { get; set; }
        public string? Kind { get; set; }
        public byte[]? Image { get; set; }
        public bool? Status { get; set; }
    }
}
