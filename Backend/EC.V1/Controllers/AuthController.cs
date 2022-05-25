using Data.Interface;
using Data.Types;
using EC.V1.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EC.V1.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAutheService _authService;
        private readonly ITokenService _tokenService;

        public AuthController(IAutheService authService, ITokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginInput loginInput)
        {
            var request = new AuthTypeInput()
            {
                Username = loginInput.Username,
                Password = loginInput.Password,
                IpAddress = Request.HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString()
            };
            var response = await _authService.Login(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenInput tokenInput)
        {
            var ipAddress = Request.HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
            return Ok(await _tokenService.GenerateRefreshToken(tokenInput.Token, ipAddress));
        }

        [Authorize]
        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _authService.GetMe(int.Parse(userId));
            return Ok(user);
        }

        [Authorize]
        [HttpPost]
        [Route("change-password")]
        public async Task ChangePasswod(ChangePassword req)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _authService.ChangePasswod(int.Parse(userId), req);
        }
    }
}
