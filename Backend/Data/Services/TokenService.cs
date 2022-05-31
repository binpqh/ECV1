using Data.Defined.Enum;
using Data.Interface;
using Data.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    /*public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly ECV1DevContext _context;
        private readonly SymmetricSecurityKey _securityKey;

        public TokenService(IConfiguration configuration, ECV1DevContext context)
        {
            _configuration = configuration;
            _context = context;
            _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
        }

        public async Task<AuthTypeResult> GenerateToken(GenerateRefreshTokenInput generateRefreshTokenInput)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
            new Claim(JwtRegisteredClaimNames.NameId, generateRefreshTokenInput.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, generateRefreshTokenInput.Username),
            new Claim("Ip", generateRefreshTokenInput.IpAddress)
        };

            var creds = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = creds
            };

            var jwtTokenHandler = new JwtSecurityTokenHandler();


            // Create the JWT security token and encode it.
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            var user = await _context.Accounts
                .Where(e => e.Uid == generateRefreshTokenInput.UserId)
                .FirstOrDefaultAsync();

            //Create Refresh Token
            var refreshToken = new RefreshToken()
            {
                IpAddress = generateRefreshTokenInput.IpAddress,
                JwtTokenId = token.Id,
                RefreshTokenString = RandomString(25) + Guid.NewGuid(),
                UserId = generateRefreshTokenInput.UserId,
            };
            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();
            //Get current user role
            var roleuser = await _context.Accounts.Where(e => e.Uid == generateRefreshTokenInput.UserId).FirstOrDefaultAsync();

            return new AuthTypeResult()
            {
                token = jwtToken,
                Success = true,
                Role = roleuser.Role
            };
        }

        public async Task<AuthTypeResult> GenerateRefreshToken(string token, string? ipV4)
        {
            var verifyToken = await VerifyToken(token, ipV4);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
            new Claim(JwtRegisteredClaimNames.NameId, verifyToken.UserId),
            new Claim(JwtRegisteredClaimNames.UniqueName, verifyToken.Username),
            new Claim("Ip", verifyToken.IpAddress)
        };

            var creds = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = creds
            };

            var jwtTokenHandler = new JwtSecurityTokenHandler();


            // Create the JWT security token and encode it.
            var jwtToken = jwtTokenHandler.CreateToken(tokenDescription);
            var accessToken = jwtTokenHandler.WriteToken(jwtToken);
            verifyToken.TokenStored.JwtTokenId = jwtToken.Id;
            await _context.SaveChangesAsync();
            return new AuthTypeResult()
            {
                Success = true,
                token = accessToken, 
                Role = verifyToken.Role,
            };
        }

        private async Task<VerifyTokenResult> VerifyToken(string token, string? ipV4)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var tokenReader = jwtTokenHandler.ReadJwtToken(token);
            var storedRefreshToken =
                await _context.RefreshTokens.FirstOrDefaultAsync(x => x.JwtTokenId == tokenReader.Id);
            if (storedRefreshToken == null) throw new Exception("Token is invalid");

            // Check ip v4
            if (storedRefreshToken.IpAddress != ipV4) throw new Exception("Token is invalid");
            var check = storedRefreshToken.IdAccountNavigation;
            var user = await _context.Accounts.FirstOrDefaultAsync(x =>
                x.Uid == storedRefreshToken.UserId.Replace(" ",""));
            if (user == null) throw new Exception("Token is invalid");

            return new VerifyTokenResult()
            {
                Username = tokenReader.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.UniqueName)?.Value,
                IpAddress = ipV4,
                UserId = storedRefreshToken.UserId,
                TokenStored = storedRefreshToken,
                Role = user.Role,
            };
        }

        private static string RandomString(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }*/
}
