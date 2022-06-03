using System;
using System.Collections.Generic;

namespace Data.Tables
{
    public partial class StudentPoint
    {
        public int Id { get; set; }
        public int? IdTranscript { get; set; }
        public int? IdPoint { get; set; }

        public virtual Point? IdPointNavigation { get; set; }
        public virtual Transcript? IdTranscriptNavigation { get; set; }
    }
}
