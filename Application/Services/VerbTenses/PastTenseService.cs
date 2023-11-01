using Domain.Contracts.Services.Verb;
using Domain.Enums;
using Domain.Models.Words;
using System.ComponentModel;

namespace Application.Services.VerbTenses
{
    public class PastTenseService : TenseService, IPastTenseService
    {
        public Verb PastTense(Verb verb)
        {
            verb.DisplayForm = verb.VerbConjugation switch
            {
                VerbConjugation.ArVerb => ArVerb(verb),
                VerbConjugation.ErVerb => ErVerb(verb),
                VerbConjugation.RVerb => RVerb(verb),
                VerbConjugation.StrongErVerb => throw new NotImplementedException(),
                _ => throw new InvalidEnumArgumentException()
            };

            return verb;
        }

        private string ArVerb(Verb verb)
        {
            return InfinitiveWithoutA(verb) + "ade";
        }

        private string ErVerb(Verb verb)
        {
            if (verb.Infinitive.EndsWith("sa") || verb.Infinitive.EndsWith("pa")
                                               || verb.Infinitive.EndsWith("ta") || verb.Infinitive.EndsWith("ka")
                                               || verb.Infinitive.EndsWith("xa"))
            {
                return InfinitiveWithoutA(verb) + "te";

            }
            return InfinitiveWithoutA(verb) + "de";
        }

        private string RVerb(Verb verb)
        {
            return verb.Infinitive + "dde";
        }
    }
}
