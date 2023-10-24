using Core.Contracts.Services;
using Core.Enums;
using Core.Models.Words;
using System.ComponentModel;

namespace Application.Services.VerbTenses
{
    public class PresentTenseService : IPresentTenseService
    {
        public Verb PresentTense(Verb verb)
        {
            verb.DisplayForm = verb.VerbConjugation switch
            {
                VerbConjugation.ArVerb => ArVerb(verb),
                VerbConjugation.ErVerb => ErVerb(verb),
                VerbConjugation.RVerb => StemVerb(verb),
                VerbConjugation.StrongErVerb => throw new NotImplementedException(),
                _ => throw new InvalidEnumArgumentException()
            };

            return verb;
        }

        private string WithoutInfinitive(Verb verb)
        {
            return verb.Infinitive.Remove(verb.Infinitive.Length - 1, 1);
        }

        private string ArVerb(Verb verb)
        {
            return WithoutInfinitive(verb) + "ar";
        }

        private string ErVerb(Verb verb)
        {
            if (verb.Infinitive.EndsWith("ra"))
            {
                return WithoutInfinitive(verb);
            }

            return WithoutInfinitive(verb) + "er";
        }

        private string StemVerb(Verb verb)
        {
            return verb.Infinitive + "r";
        }
    }
}
