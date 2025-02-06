using Application;
using Infrastructure;

namespace API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services)
        {
            services.AddApplicationDI()
                    .AddInfrastructureDI();

            return services;
        }
    }
}
