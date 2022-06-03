using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Types
{
    public class StudentPointTypeResult
    {
        public int Id { get; set; }
        public int? IdTranscript { get; set; }
        public int? IdPoint { get; set; }
    }
    public class StudentPointTypeInput
    {
        public int? IdTranscript { get; set; }
        public int? IdPoint { get; set; }
    }
}
