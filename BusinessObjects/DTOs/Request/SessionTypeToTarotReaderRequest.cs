using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs.Request
{
    public class SessionTypeToTarotReaderRequest
    {
        public int TarotReaderId { get; set; }
        public int SessionTypeId { get; set; }
    }
}
