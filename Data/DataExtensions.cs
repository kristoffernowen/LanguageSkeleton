using Application.Contracts.Repos;
using Data.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDataExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlContext>(x => x.UseSqlite(configuration.GetConnectionString("Sql")));
            services.AddScoped<IVerbRepo, VerbRepo>();
            services.AddScoped<INounRepo, NounRepo>();
            var licenseKey = configuration["LuckyPennyLicense"];
            services.AddAutoMapper(cfg =>
            {
                cfg.LicenseKey = licenseKey;
            }, 
                AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
