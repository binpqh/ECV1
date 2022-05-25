using Data.Defined.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Types
{
    public class AuthTypeResult
    {
        public bool Success { get; set; } = false;
        public RoleEnum Role { get; set; }
        public string? token { get; set; }
    }
    public class AuthTypeInput
    {
        [Required] public string? Username { get; set; }
        [Required] public string? Password { get; set; }
        [Required] public string? IpAddress { get; set; }

    }
    public class ChangePassword
    {
        [Required] public string? OldPassword { get; set; }
        [Required] public string? NewPassword { get; set; }
        [Required] public string? ConfirmPassword { get; set; }
    }
}
