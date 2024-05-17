using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class TarotReaderSessionType
    {
        public int TarotReaderId { get; set; }
        public int SessionTypeId { get; set; }

        public virtual SessionType SessionType { get; set; } = null!;
        public virtual TarotReader TarotReader { get; set; } = null!;
    }
}
