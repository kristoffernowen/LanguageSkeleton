using Domain.Contracts.Services.Verb;
using Domain.Enums;
using Domain.Models.Words;
using System.ComponentModel;

namespace Application.Services.VerbTenses
{
    public class PresentTenseService : TenseService, IPresentTenseService
    {
        public Verb PresentTense(Verb verb)
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
            return InfinitiveWithoutA(verb) + "ar";
        }

        private string ErVerb(Verb verb)
        {
            if (verb.Infinitive.EndsWith("ra"))
            {
                return InfinitiveWithoutA(verb);
            }

            return InfinitiveWithoutA(verb) + "er";
        }

        private string RVerb(Verb verb)
        {
            return verb.Infinitive + "r";
        }
    }
}
