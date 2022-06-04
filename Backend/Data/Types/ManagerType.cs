using Data.Defined.Enum;
using Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Types
{
    public class ManagerTypeResult
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Birthday { get; set; }
        public string? Address { get; set; }
        public int? IdAccount { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public Status Status { get; set; }

    }
    public class ManagerTypeInput
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Birthday { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? IdAccount { get; set; }
    }
}
