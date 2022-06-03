using Data.Defined.Enum;
using System;
using System.Collections.Generic;

namespace Data.Tables
{
    public partial class Point
    {
        public Point()
        {
            StudentPoints = new HashSet<StudentPoint>();
        }

        public int Id { get; set; }
        public string? Point1 { get; set; }
        public Status Status { get; set; }

        public virtual ICollection<StudentPoint> StudentPoints { get; set; }
    }
}
