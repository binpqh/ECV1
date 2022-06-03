using Data.Defined.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Types
{
    public class TimeTableTypeResult
    {
        public int? IdClass { get; set; }
        public WeekdayEnum? weekday { get; set; }
    }
    public class TimeTableInput
    {
        public WeekdayEnum? weekday { get; set; }
    }
}
