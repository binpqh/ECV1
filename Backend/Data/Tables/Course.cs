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
        public string? CourseName { get; set; }
        public DateTime? StartDay { get; set; }
        public DateTime? EndDay { get; set; }
        public decimal? Cost { get; set; }
        public string? Level { get; set; }
        public string? Description { get; set; }
        public byte[]? Image { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
