using System.ComponentModel;
using Core.Contracts.Services.Verb;
using Core.Enums;
using Core.Models.Words;

namespace Application.Services
{
    public class VerbTenseService : IVerbTenseService
    {
        public Verb PresentTense(Verb verb)
        {
            verb.DisplayForm = verb.VerbConjugation switch
            {
                VerbConjugation.ArVerb => verb.Infinitive.Remove(verb.Infinitive.Length - 1, 1) + "ar",
                VerbConjugation.ErVerb => ErVerbPresentTense(verb),
                VerbConjugation.RVerb => verb.Infinitive + "r",
                VerbConjugation.StrongErVerb => throw new NotImplementedException(),
                _ => throw new InvalidEnumArgumentException()
            };

            return verb;
        }

        public Verb PastTense(Verb verb)
        {
            verb.DisplayForm = verb.VerbConjugation switch
            {
                VerbConjugation.ArVerb => verb.Infinitive.Remove(verb.Infinitive.Length - 1, 1) + "ade",
                VerbConjugation.ErVerb => ErVerbPastTense(verb),
                VerbConjugation.RVerb => verb.Infinitive + "r",
                VerbConjugation.StrongErVerb => throw new NotImplementedException(),
                _ => throw new InvalidEnumArgumentException()
            };

            return verb;
        }

        public Verb FutureTense(Verb verb)
        {
            throw new NotImplementedException();
        }

        public Verb PerfectTense(Verb verb)
        {
            throw new NotImplementedException();
        }

        private string ErVerbPresentTense(Verb verb)
        {
            if (verb.Infinitive.EndsWith("ra"))
            {
                return verb.Infinitive.Remove(verb.Infinitive.Length - 1, 1);
            }

            return verb.Infinitive.Remove(verb.Infinitive.Length - 1, 1) + "er";
        }
        private string ErVerbPastTense(Verb verb)
        {
            if (verb.Infinitive.EndsWith("sa") || verb.Infinitive.EndsWith("pa")
                                                  || verb.Infinitive.EndsWith("ta") || verb.Infinitive.EndsWith("ka")
                                                  || verb.Infinitive.EndsWith("xa"))
            {
                return verb.Infinitive.Remove(verb.Infinitive.Length - 1, 1) + "te";
                
            }
            return verb.Infinitive.Remove(verb.Infinitive.Length - 1, 1) + "de";
            
        }
        private Verb Supinum(Verb verb)
        {
            return verb;
        }
    }
}
