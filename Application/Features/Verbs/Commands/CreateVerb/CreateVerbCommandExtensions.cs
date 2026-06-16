using System.ComponentModel;
using Domain.Enums.Verb;
using Domain.Models.Words;

namespace Application.Features.Verbs.Commands.CreateVerb;

public static class CreateVerbCommandExtensions
{
    public static Verb ToModel(this CreateVerbCommand request)
    {
        var verb = new Verb
        {
            Infinitive = request.Infinitive,
            VerbConjugation = request.VerbConjugation switch
            {
                "One" => VerbConjugation.WeakOne,
                "Two" => VerbConjugation.WeakTwo,
                "Three" => VerbConjugation.WeakThree,
                "Four" => VerbConjugation.StrongFour,
                "Irregular" => VerbConjugation.Irregular,
                _ => throw new InvalidEnumArgumentException()
            },
            Imperative = request.Imperative,
            PresentTense = request.PresentTense,
            PastTense = request.PastTense,
            Supine = request.Supine
        };

        return verb;
    }
}