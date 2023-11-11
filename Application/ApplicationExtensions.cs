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

namespace Application
{
    public static class ApplicationExtensions
    {
        
            public static IServiceCollection AddApplicationExtensions(this IServiceCollection services)
            {
                services.AddScoped<IPopulateSentenceService, PopulateSentenceService>();
                services.AddScoped<IVerbService, VerbService>();
                services.AddScoped<INounService, NounService>();
                services.AddScoped<IPresentTenseService, PresentTenseService>();
                services.AddScoped<IPastTenseService, PastTenseService>();
                services.AddScoped<IPerfectTenseService, PerfectTenseService>();
                services.AddScoped<IFutureTenseService, FutureTenseService>();
                services.AddScoped<IGrammaticalNumberService, GrammaticalNumberService>();
                services.AddScoped<IDefinitenessService, DefinitenessService>();
                services.AddScoped<IWordOrderService, WordOrderService>();
                services.AddScoped<IArrangeClauseElementService, ArrangeClauseElementService>();
                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

                return services;
            }
        
    }
}
