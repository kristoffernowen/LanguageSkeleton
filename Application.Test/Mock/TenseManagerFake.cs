using Application.Contracts.Services.Verb;
using Application.Services.VerbTenses;
using Domain.Enums;
using Domain.Models.Words;
using System.ComponentModel;

namespace Application.Test.Mock
{
    public class TenseManagerFake : ITenseManager
    {
        private readonly Lazy<IPresentTenseService> _presentTenseService = new(() => new PresentTenseService());
        private readonly Lazy<IPastTenseService> _pastTenseService = new(() => new PastTenseService());
        private readonly Lazy<IPerfectTenseService> _perfectTenseService = new(() => new PerfectTenseService());
        private readonly Lazy<IFutureTenseService> _futureTenseService = new(() => new FutureTenseService());

        public Verb SetDisplayForm(Tense tense, Verb verb)
        {
            return tense switch
            {
                Tense.Present => _presentTenseService.Value.SetDisplayForm(verb),
                Tense.Past => _pastTenseService.Value.SetDisplayForm(verb),
                Tense.Perfect => _perfectTenseService.Value.SetDisplayForm(verb),
                Tense.Future => _futureTenseService.Value.SetDisplayForm(verb),
                _ => throw new InvalidEnumArgumentException()
            };
        }
    }
}
