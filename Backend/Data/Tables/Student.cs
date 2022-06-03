using Data.Defined.Enum;
using System;
using System.Collections.Generic;

namespace Data.Tables
{
    public partial class Student
    {
        public Student()
        {
            Transcripts = new HashSet<Transcript>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Birthday { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public int? Classkey { get; set; }
        public int? IdAccount { get; set; }
        public string? Phone { get; set; }
        public Status Status { get; set; }

        public virtual Class? ClasskeyNavigation { get; set; }
        public virtual Account? IdAccountNavigation { get; set; }
        public virtual ICollection<Transcript> Transcripts { get; set; }
    }
}
