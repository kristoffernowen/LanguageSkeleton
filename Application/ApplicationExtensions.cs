using System.Reflection;
using Application.Contracts.Services.Noun;
using Application.Contracts.Services.Sentence;
using Application.Contracts.Services.Verb;
using Application.Services;
using Application.Services.Clause;
using Application.Services.NounForms;
using Application.Services.VerbTenses;
using Domain.Enums;
using Microsoft.Extensions.DependencyInjection;
using Definiteness = Application.Services.NounForms.Definiteness;
using GrammaticalNumber = Application.Services.NounForms.GrammaticalNumber;

namespace Application
{
    public static class ApplicationExtensions
    {
        
            public static IServiceCollection AddApplicationExtensions(this IServiceCollection services)
            {
                // services.AddScoped<INounService, NounService>();
                services.AddScoped<IPresentTenseService, PresentTenseService>();
                services.AddScoped<IPastTenseService, PastTenseService>();
                services.AddScoped<IPerfectTenseService, PerfectTenseService>();
                services.AddScoped<IFutureTenseService, FutureTenseService>();
                services.AddScoped<IGrammaticalNumber, GrammaticalNumber>();
                services.AddScoped<IDefiniteness, Definiteness>();
                services.AddScoped<IWordOrderService, WordOrderService>();
                services.AddScoped<IArrangeClauseElementService, ArrangeClauseElementService>();
                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
                services.AddScoped<INounManager, NounManager>();
                services.AddScoped<ITenseManager, TenseManager>();

                return services;
            }
        
    }
}
