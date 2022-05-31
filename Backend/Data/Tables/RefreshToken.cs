using System;
using System.Collections.Generic;

namespace Data.Tables
{
    public partial class RefreshToken
    {
        public int Id { get; set; }
        public string? RefreshTokenString { get; set; }
        public string? UserId { get; set; }
        public string? JwtTokenId { get; set; }
        public string? IpAddress { get; set; }
        public int? IdAccountNavigationId { get; set; }

        public virtual Account? IdAccountNavigation { get; set; }
    }
}
