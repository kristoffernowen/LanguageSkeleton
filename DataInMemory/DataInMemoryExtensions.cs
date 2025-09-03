using Application.Contracts.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace DataInMemory
{
    public static class DataInMemoryExtensions
    {
        public static IServiceCollection AddDataInMemory(this IServiceCollection services)
        {
            services.AddScoped<INounRepo, NounRepo>();
            services.AddScoped<IVerbRepo, VerbRepo>();

            return services;
        }
    }
}
