using System.Reflection;
using Application.Contracts.Services.Noun;
using Application.Contracts.Services.Sentence;
using Application.Contracts.Services.Verb;
using Application.Services;
using Application.Services.Clause;
using Application.Services.VerbTenses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationExtensions
    {
            public static IServiceCollection AddApplicationExtensions(this IServiceCollection services, IConfiguration configuration)
            {
                services.AddScoped<IPresentTenseService, PresentTenseService>();
                services.AddScoped<IPastTenseService, PastTenseService>();
                services.AddScoped<IPerfectTenseService, PerfectTenseService>();
                services.AddScoped<IFutureTenseService, FutureTenseService>();
                services.AddScoped<IWordOrderService, WordOrderService>();
                services.AddScoped<IArrangeClauseElementService, ArrangeClauseElementService>();
                services.AddMediatR(cfg => {
                {
                    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
                    cfg.LicenseKey = configuration["LuckyPennyLicense"];
                } });
                services.AddScoped<ITenseManager, TenseManager>();

                return services;
            }
    }
}
