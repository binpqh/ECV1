using Data.Defined.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Types
{
    public class TranscriptTypeResult
    {
        public int Id { get; set; }
        public int? IdTeacher { get; set; }
        public int? IdStudent { get; set; }
        public int? IdManager { get; set; }
        public int? IdClass { get; set; }
        public int? IdPoint { get; set; }
        public bool? StatusPay { get; set; }
    }
    public class TranscriptTypeInput
    {
        public int? IdTeacher { get; set; }
        public int? IdStudent { get; set; }
        public int? IdManager { get; set; }
        public int? IdClass { get; set; }
        public bool? StatusPay { get; set; }
        public Status Status { get; set; }
    }
}
