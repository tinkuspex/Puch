using Business;
using Services;

namespace PruebaApi.Service
{
    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddMyDependencyGroup(
             this IServiceCollection services)
        {
            services.AddScoped<IAlumnoBusiness, AlumnoBusiness>();
            services.AddScoped<IAlumnoService, AlumnoService>();

            return services;
        }
    }
}
