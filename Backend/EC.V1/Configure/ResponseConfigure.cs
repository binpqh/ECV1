using EC.V1.Defined;
using Microsoft.AspNetCore.Diagnostics;

namespace EC.V1.Configure
{
    public static class ResponseConfigure
    {
        public static void ConfigureErrorResponse(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(c => c.Run(async context =>
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                .Error;

                const EnumResponses code = EnumResponses.InternalServerError;
                var desc = exception.Message;

                await context.Response.WriteAsJsonAsync(new
                {
                    Code = code,
                    Desc = desc
                });
            }));
        }
    }
}
