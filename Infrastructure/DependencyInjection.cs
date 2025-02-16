using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Server=.;Database=DailyJournal;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");
            });

            services.AddScoped<IJournalRepository, JournalRepository>();

            return services;
        }
    }
}
