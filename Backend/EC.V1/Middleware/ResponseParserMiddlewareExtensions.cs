using EC.V1.Defined;
using EC.V1.Types;
using System.Text.Json;

namespace EC.V1.Middleware
{
    public static class ResponseParserMiddlewareExtensions
    {
        public static IApplicationBuilder UseResponseParser(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseParserMiddleware>();
        }

        public class ResponseParserMiddleware
        {
            private readonly RequestDelegate _next;

            public ResponseParserMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task InvokeAsync(HttpContext context)
            {
                var originBody = context.Response.Body;
                try
                {
                    var memStream = new MemoryStream();
                    context.Response.Body = memStream;

                    await _next(context).ConfigureAwait(false);

                    memStream.Position = 0;
                    var responseBody = new StreamReader(memStream).ReadToEnd();

                    var statusCode = context.Response.StatusCode;
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    };
                    if (statusCode == 404)
                    {
                        context.Response.ContentType = "application/json";

                        responseBody =
                            JsonSerializer.Serialize(Responses.Error(EnumResponses.NotFound, "Not Found"), options);
                    }
                    else
                    {
                        if (responseBody.Length == 0)
                        {
                            context.Response.ContentType = "application/json";

                            responseBody = JsonSerializer.Serialize(Responses.Success("Success"), options);
                        }
                    }

                    var memoryStreamModified = new MemoryStream();
                    var sw = new StreamWriter(memoryStreamModified);
                    sw.Write(responseBody);
                    sw.Flush();
                    memoryStreamModified.Position = 0;

                    await memoryStreamModified.CopyToAsync(originBody).ConfigureAwait(false);
                }
                finally
                {
                    context.Response.Body = originBody;
                }
            }
        }
    }
}
