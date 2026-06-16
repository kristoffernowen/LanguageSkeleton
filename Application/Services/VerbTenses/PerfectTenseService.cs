using Application.Contracts.Services.Verb;
using Domain.Enums.Verb;
using Domain.Models.Words;
using System.ComponentModel;

namespace Application.Services.VerbTenses
{
    public class PerfectTenseService : IPerfectTenseService
    {

        public Verb SetDisplayForm(Verb verb)
        {
            verb.DisplayForm = verb.VerbConjugation switch
            {
                VerbConjugation.WeakOne => ArVerb(verb),
                VerbConjugation.WeakTwo => ErVerb(verb),
                VerbConjugation.WeakThree => RVerb(verb),
                VerbConjugation.StrongFour => StrongErVerb(verb),
                VerbConjugation.Irregular => verb.Supine,
                _ => throw new InvalidEnumArgumentException()
            };

            return verb;
        }

        private string ArVerb(Verb verb)
        {
            return verb.Imperative + "t";
        }

        private string ErVerb(Verb verb)
        {
            return verb.Imperative + "t";
        }

        private string RVerb(Verb verb)
        {
            return verb.Imperative + "tt";
        }

        private string StrongErVerb(Verb verb) // will miss to change bära/bär to burit and kommer/kom to kommit, but nevermind. I will refactor to use forms persisted to db, not derived like here, when I refactor Verb Domain model
        {
            if (verb.Imperative.Length > 2 && verb.Imperative[^3] is 'i' or 'ä') 
            {
                verb.DisplayForm = ChangeShortStemVowelTo(verb.Imperative, "u");
                return verb.DisplayForm + "it";
            }
            if (verb.Imperative[^2] != 'y') return verb.Imperative + "it";

            verb.DisplayForm = ChangeLongStemVowelTo(verb.Imperative, "u");
            return verb.DisplayForm + "it";
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
