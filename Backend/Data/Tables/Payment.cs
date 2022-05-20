using System;
using System.Collections.Generic;

namespace Data.Tables
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public string? Status { get; set; }
        public int? ManagerId { get; set; }

        public virtual Manager? Manager { get; set; }
        public virtual Student? Student { get; set; }
    }
}
