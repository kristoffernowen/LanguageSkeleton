using Domain.Enums;
using Domain.Models.Words;
using System.ComponentModel;
using Application.Contracts.Services.Verb;

namespace Application.Services.VerbTenses
{
    public class PastTenseService : IPastTenseService
    {
        public Verb SetDisplayForm(Verb verb)
        {
            verb.DisplayForm = verb.VerbConjugation switch
            {
                VerbConjugation.ArVerb => ArVerb(verb),
                VerbConjugation.ErVerb => ErVerb(verb),
                VerbConjugation.RVerb => RVerb(verb),
                VerbConjugation.StrongErVerb => StrongErVerb(verb),
                VerbConjugation.IrregularVerb => verb.PastTense,
                _ => throw new InvalidEnumArgumentException()
            };

            return verb;
        }

        private string ArVerb(Verb verb)
        {
            return verb.Imperative + "de";
        }

        private string ErVerb(Verb verb)
        {
            if (verb.Imperative.EndsWith("s") || verb.Imperative.EndsWith("p")
                                               || verb.Imperative.EndsWith("t") || verb.Imperative.EndsWith("k")
                                               || verb.Imperative.EndsWith("x"))
            {
                return verb.Imperative + "te";

            }
            return verb.Imperative + "de";
        }

        private string RVerb(Verb verb)
        {
            return verb.Imperative + "dde";
        }

        private string StrongErVerb(Verb verb)
        {
            if (verb.Imperative[^3] is 'i' or 'ä')
            {
                verb.DisplayForm = ChangeShortStemVowelTo(verb.Imperative, "a");
            }
            else
                verb.DisplayForm = verb.Imperative[^2] switch
                {
                    'i' => ChangeLongStemVowelTo(verb.Imperative, "e"),
                    'u' => ChangeLongStemVowelTo(verb.Imperative, "ö"),
                    'y' => ChangeLongStemVowelTo(verb.Imperative, "ö"),
                    'a' => ChangeLongStemVowelTo(verb.Imperative, "o"),
                    'å' => ChangeLongStemVowelTo(verb.Imperative, "ä"),
                    _ => throw new ApplicationException("aktiverade ingen förväntad verbregel för starka er verb")
                };

            return verb.DisplayForm;
        }

        private string ChangeLongStemVowelTo(string displayForm, string newVowel)
        {
            return string.Concat(displayForm.Remove(displayForm.Length - 2), newVowel,
                displayForm[^1]);
        }
        private string ChangeShortStemVowelTo(string displayForm, string newVowel)
        {
            return string.Concat(displayForm.Remove(displayForm.Length - 3), newVowel,
                displayForm.AsSpan(displayForm.Length - 2, 2));
        }
    }
}
