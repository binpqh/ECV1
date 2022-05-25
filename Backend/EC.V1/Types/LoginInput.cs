using System.ComponentModel.DataAnnotations;

namespace EC.V1.Types
{
    public class LoginInput
    {
        [Required] public string? Username { get; set; }
        [Required] public string? Password { get; set; }
    }
    public class RefreshTokenInput
    {
        [Required] public string? Token { get; set; }
    }
}
