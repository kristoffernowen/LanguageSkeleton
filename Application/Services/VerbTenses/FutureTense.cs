using System.ComponentModel;
using Domain.Enums;
using Domain.Models.Sentence;
using Domain.Models.Words;

namespace Application.Services.VerbTenses;

public class FutureTense : TenseBehavior
{
    public override Verb SetDisplayForm(Verb verb)
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
        return verb.Imperative + "a";
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