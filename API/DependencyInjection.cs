using Application;
using Infrastructure;
using Domain;

namespace API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI()
                    .AddInfrastructureDI()
                    .AddDomainDI(configuration);

            return services;
        }
    }
}
