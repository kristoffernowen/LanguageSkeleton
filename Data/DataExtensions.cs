using Core.Contracts.Repos;
using Data.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDataExtensions(this IServiceCollection services, IConfiguration builder)
        {
            services.AddDbContext<SqlContext>(x => x.UseSqlServer(builder.GetConnectionString("Sql")));
            services.AddScoped<IVerbRepo, VerbRepo>();
            services.AddScoped<INounRepo, NounRepo>();

            return services;
        }
    }
}
