using System;
using System.Collections.Generic;

namespace Data.Tables
{
    public partial class Course
    {

        public int Id { get; set; }
        public string? Coursename { get; set; }
        public string? DayStart { get; set; }
        public string? DayEnd { get; set; }
        public decimal? Price { get; set; }
        public string? Level { get; set; }
        public int Status { get; set; }

        public virtual List<Class>? Classes { get; set; } // FK Class-Course
    }
}
