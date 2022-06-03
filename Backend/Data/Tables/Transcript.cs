using Data.Defined.Enum;
using System;
using System.Collections.Generic;

namespace Data.Tables
{
    public partial class Transcript
    {
        public Transcript()
        {
            StudentPoints = new HashSet<StudentPoint>();
        }

        public int Id { get; set; }
        public int? IdTeacher { get; set; }
        public int? IdStudent { get; set; }
        public int? IdManager { get; set; }
        public int? IdClass { get; set; }
        public int? IdPoint { get; set; }
        public bool? StatusPay { get; set; }
        public Status Status { get; set; }

        public virtual Class? IdClassNavigation { get; set; }
        public virtual Manager? IdManagerNavigation { get; set; }
        public virtual Student? IdStudentNavigation { get; set; }
        public virtual Teacher? IdTeacherNavigation { get; set; }
        public virtual ICollection<StudentPoint> StudentPoints { get; set; }
    }
}
