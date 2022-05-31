using System;
using System.Collections.Generic;

namespace Data.Tables
{
    public partial class Account
    {
        public Account()
        {
            Managers = new HashSet<Manager>();
            RefreshTokens = new HashSet<RefreshToken>();
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string? Uid { get; set; }
        public string? Password { get; set; }
        public int Role { get; set; }

        public virtual ICollection<Manager> Managers { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
