using Data.Defined.Enum;
using System;
using System.Collections.Generic;

namespace Data.Tables
{
    public partial class Classday
    {
        public int Id { get; set; }
        public WeekdayEnum Weekday { get; set; }
        public int? Class { get; set; }

        public virtual Class? ClassNavigation { get; set; }
    }
}
