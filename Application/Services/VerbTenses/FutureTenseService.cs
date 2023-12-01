using Application.Contracts.Services.Verb;
using Domain.Enums;
using Domain.Models.Words;
using System.ComponentModel;

namespace Application.Services.VerbTenses
{
    public class FutureTenseService : IFutureTenseService
    {
        public Verb SetDisplayForm(Verb verb)
        {
            verb.DisplayForm = verb.VerbConjugation switch
            {
                VerbConjugation.ArVerb => ArVerb(verb),
                VerbConjugation.ErVerb => ErVerb(verb),
                VerbConjugation.RVerb => RVerb(verb),
                VerbConjugation.StrongErVerb => StrongErVerb(verb),
                VerbConjugation.IrregularVerb => verb.Infinitive,
                _ => throw new InvalidEnumArgumentException()
            };

            return verb;
        }

        private string ArVerb(Verb verb)
        {
            return verb.Imperative;
        }

        private string ErVerb(Verb verb)
        {
            return verb.Imperative + "a";
        }

        private string RVerb(Verb verb)
        {
            return verb.Imperative;
        }

        private string StrongErVerb(Verb verb)
        {
            return verb.Imperative + "a";
        }
    }
}
