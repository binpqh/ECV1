﻿using Data;
using Data.Interface;
using Data.Services;

namespace EC.V1.Configure
{
    public static class DatabaseConfigure
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped((_) => new ECV1DevContext());

            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IClassService, ClassService>();
        }
    }
}

