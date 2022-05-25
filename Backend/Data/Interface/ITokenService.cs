using Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface ITokenService
    {
        Task<AuthTypeResult> GenerateToken(GenerateRefreshTokenInput generateRefreshTokenInput);
        Task<AuthTypeResult> GenerateRefreshToken(string token, string? ipV4);
    }
}
