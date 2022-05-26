using System.Text.Json;

namespace EC.V1.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Viết lại response 401
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context), nameof(context) + " is required");
            }

            if (context.User.Identity is { IsAuthenticated: true })
            {
                var ipAddress = context.Connection.RemoteIpAddress?.MapToIPv4().ToString();
                var claimIp = context.User.FindFirst(x => x.Type == "Ip")?.Value;
                if (claimIp != ipAddress)
                {
                    throw new ArgumentNullException(nameof(context), "Wrong Address" + ipAddress);
                }
            }

            await _next(context);

            if (context.Response.StatusCode == 401)
            {
                context.Response.ContentType = "application/json";
                await using var writer = new Utf8JsonWriter(context.Response.BodyWriter);
                writer.WriteStartObject();
                writer.WriteNumber("code", 401);
                writer.WriteString("desc", "Auth failed");
                writer.WriteEndObject();
                await writer.FlushAsync();
            }
        }
    }
}
