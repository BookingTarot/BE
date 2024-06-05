using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs.Request
{
    public class FeedBackRequest
    {
        
        public int CustomerId { get; set; }
        public int TarotReaderId { get; set; }
        public int? Rating { get; set; }
        public string? Comments { get; set; }
        
    }
}
