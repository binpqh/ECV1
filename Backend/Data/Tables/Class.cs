using Data.Defined.Enum;
using System;
using System.Collections.Generic;

namespace Data.Tables
{
    public partial class Class
    {
        public Class()
        {
            Classdays = new HashSet<Classday>();
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string? Classname { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? LinkGgmeet { get; set; }
        public int IdCourse { get; set; }
        public Status Status { get; set; }

        public virtual Course IdCourseNavigation { get; set; } = null!;
        public virtual ICollection<Classday> Classdays { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
