using Data;
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
            services.AddScoped<IAutheService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITranscriptService,TranscriptService>();
            services.AddScoped<IStudentPointService, StudentPointService>();
        }
    }
}

