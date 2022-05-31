using System;
using System.Collections.Generic;

namespace Data.Tables
{
    public partial class Course
    {
        public Course()
        {
            Classes = new HashSet<Class>();
        }

        public int Id { get; set; }
        public string? Coursename { get; set; }
        public string? DayStart { get; set; }
        public string? DayEnd { get; set; }
        public decimal? Price { get; set; }
        public string? Level { get; set; }
        public int Status { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
