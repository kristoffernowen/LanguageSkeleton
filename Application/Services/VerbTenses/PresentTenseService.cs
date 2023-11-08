using Domain.Enums;
using Domain.Models.Words;
using System.ComponentModel;
using Application.Contracts.Services.Verb;

namespace Application.Services.VerbTenses
{
    public class PresentTenseService : TenseService, IPresentTenseService
    {
        public Verb PresentTense(Verb verb)
        {
            verb.DisplayForm = verb.PresentTense;

            return verb;
        }

        
    }
}
