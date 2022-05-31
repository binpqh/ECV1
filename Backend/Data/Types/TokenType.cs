using Data.Defined.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Types
{
    public class GenerateRefreshTokenInput
    {
        public string? UserId { get; set; }
        public string? Username { get; set; }
        public string? IpAddress { get; set; }

    }
    public class VerifyTokenResult
    {
        public string? UserId { get; set; }
        public string? Username { get; set; }
        public string? IpAddress { get; set; }
        public RoleEnum Role { get; set; }
        //public RefreshToken? TokenStored { get; set; }
    }
}
