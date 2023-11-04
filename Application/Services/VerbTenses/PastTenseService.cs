using Domain.Enums;
using Domain.Models.Words;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Application.Contracts.Services.Verb;

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
                VerbConjugation.StrongErVerb => StrongErVerb(verb),
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

        private string StrongErVerb(Verb verb)
        {
            var matchEndingWithABeforeDoubleConsonantBeforeI = "([i][^aeiouyåäö]{2}[a])$";
            if (Regex.IsMatch(verb.Infinitive, $"{matchEndingWithABeforeDoubleConsonantBeforeI}"))
            {
                verb.DisplayForm = InfinitiveWithoutA(verb);
                verb.DisplayForm = verb.DisplayForm.Remove(verb.DisplayForm.Length - 3) + "a" +
                                   verb.DisplayForm.Substring(verb.DisplayForm.Length - 2);
            }
            else switch (verb.Infinitive[^3])
            {
                case 'i':
                    verb.DisplayForm = InfinitiveWithoutA(verb);
                    verb.DisplayForm = verb.DisplayForm.Remove(verb.DisplayForm.Length - 2) + "e" +
                                       verb.DisplayForm.Substring(verb.DisplayForm.Length - 1);
                    break;
                case 'u':
                case 'y':
                    verb.DisplayForm = InfinitiveWithoutA(verb);
                    verb.DisplayForm = verb.DisplayForm.Remove(verb.DisplayForm.Length - 2) + "ö" +
                                       verb.DisplayForm.Substring(verb.DisplayForm.Length - 1);
                    break;
                default:
                    throw new ApplicationException("aktiverade ingen förväntad verbregel för starka er verb");
            }

            return verb.DisplayForm;
        }
    }
}
