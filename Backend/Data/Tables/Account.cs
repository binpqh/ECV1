using System;
using System.Collections.Generic;

namespace Data.Tables
{
    public partial class Account
    {

        public int Id { get; set; }
        public string? Uid { get; set; }
        public string? Password { get; set; }

        public virtual List<Manager>? Managers { get; set; }
        public virtual List<Student>? Students { get; set; }
        public virtual List<Teacher>? Teachers { get; set; }
    }
}
