using System.Reflection;
using cnpmnc.backend;
using cnpmnc.backend.Service;
using cnpmnc.shared.Interfaces;
namespace cnpmnc.backend
{
    public static class ServiceRegister
    {
        public static void AddBusinessLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            // services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<IGradeService, GradeService>();
            services.AddTransient<ILiteracyService, LiteracyService>();
        }
    }
}