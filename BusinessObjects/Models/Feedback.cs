using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public int CustomerId { get; set; }
        public int TarotReaderId { get; set; }
        public int? Rating { get; set; }
        public string? Comments { get; set; }
        public DateTime? Date { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual TarotReader TarotReader { get; set; } = null!;
    }
}
