using Domain.Enums;
using Domain.Models.Words;
using System.ComponentModel;
using Application.Contracts.Services.Verb;

namespace Application.Services.VerbTenses
{
    public class PresentTenseService : IPresentTenseService
    {
        public Verb SetDisplayForm(Verb verb)
        {
            verb.DisplayForm = verb.PresentTense;

            return verb;
        }
    }
}
