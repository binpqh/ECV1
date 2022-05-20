using System;
using System.Collections.Generic;

namespace Data.Tables
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
            IdWeekdays = new HashSet<Weekday>();
        }

        public int Id { get; set; }
        public string? Classname { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? LinkGgmeet { get; set; }
        public int IdCourse { get; set; }

        public virtual Course IdCourseNavigation { get; set; } = null!;
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }

        public virtual ICollection<Weekday> IdWeekdays { get; set; }
    }
}
