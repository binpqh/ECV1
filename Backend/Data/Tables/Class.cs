using Data.Defined.Enum;
using System.Collections.Generic;

namespace Data.Tables
{
    public partial class Class
    {

        public int Id { get; set; }
        public string? Classname { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? LinkGgmeet { get; set; }
        public int IdCourse { get; set; }
        public Status Status { get; set; }

        public virtual Course IdCourseNavigation { get; set; } = null!;
        public virtual List<Student>? Students { get; set; }
        public virtual List<Teacher>? Teachers { get; set; }
        public virtual List<Weekday>? IdWeekdays { get; set; } // many-many ClasDay
    }
}
