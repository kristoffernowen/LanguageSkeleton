using Application.Services;
using Application.Services.NounForms;
using Core.Contracts.Services.Noun;
using Core.Contracts.Services.Sentence;
using Core.Contracts.Services.Verb;
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
                services.AddScoped<IVerbTenseService, VerbTenseService>();
                services.AddScoped<IGrammaticalNumberService, GrammaticalNumberService>();
                services.AddScoped<IDefinitenessService, DefinitenessService>();
               

                return services;
            }
        
    }
}
