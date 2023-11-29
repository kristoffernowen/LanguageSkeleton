using System.ComponentModel;
using Domain.Enums;
using Domain.Models.Sentence;
using Domain.Models.Words;

namespace Application.Services.VerbTenses;

public class PerfectTense : TenseBehavior
{
    public override Verb SetDisplayForm(Verb verb)
    {
        verb.DisplayForm = verb.VerbConjugation switch
        {
            VerbConjugation.ArVerb => ArVerb(verb),
            VerbConjugation.ErVerb => ErVerb(verb),
            VerbConjugation.RVerb => RVerb(verb),
            VerbConjugation.StrongErVerb => StrongErVerb(verb),
            VerbConjugation.IrregularVerb => verb.Supine,
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

    private string StrongErVerb(Verb verb)
    {
        if (verb.Imperative[^3] is 'i' or 'ä')
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