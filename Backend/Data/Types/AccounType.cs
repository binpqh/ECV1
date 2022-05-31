using Data.Defined.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Types
{
    public class AccountTypeResult
    {
        public int Id { get; set; }
        public string? Uid { get; set; }
        public string? Password { get; set; }
        public RoleEnum Role { get; set; }
    }
    public class AccountTypeInput
    {
        public string? Uid { get; set; }
        public string? Password { get; set; }
    }
}
