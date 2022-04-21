using System.Reflection;
using cnpmnc.frontend.Service;

namespace cnpmnc.frontend
{
    public static class ServiceRegister
    {
        public static void AddBusinessLayer(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<ICourseService, CourseService>();
            services.AddRazorPages();
        }
    }
}