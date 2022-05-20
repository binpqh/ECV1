using EC.V1.Types;
using Microsoft.AspNetCore.Mvc;

namespace EC.V1.Configure
{
    public static class ControllerConfigure
    {
        public static void ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers()
                // .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .ConfigureApiBehaviorOptions(options =>
                {
                // Viết lại response 400
                options.InvalidModelStateResponseFactory = context => new BadRequestObjectResult(new BadRequestResponse(context));
                });
        }
    }
}
