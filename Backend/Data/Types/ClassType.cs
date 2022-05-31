using Data.Defined.Enum;
using Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Types
{
    public class ClassResult
    {
        public int Id { get; set; }
        public string? ClassName { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? LinkGGMeet { get; set; }
        public int IdCourse { get; set; }
        public ICollection<Classday>? Weekdays { get; set; }


    }
    public class ClassInput
    {
        public string? ClassName { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? LinkGGMeet { get; set; }
        public int IdCourse { get; set; }
        public ICollection<Classday>? Weekdays { get; set; }
    }
}
