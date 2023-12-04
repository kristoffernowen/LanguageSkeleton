using System.ComponentModel;
using Domain.Enums;
using Domain.Models.Words;

namespace Application.Features.Verbs.Commands.CreateVerb;

public static class CreateVerbCommandExtensions
{
    public static Verb ToModel(this CreateVerbCommand request)
    {
        var verb = new Domain.Models.Words.Verb
        {
            Infinitive = request.Infinitive,
            VerbConjugation = request.VerbConjugation switch
            {
                "ArVerb" => VerbConjugation.ArVerb,
                "ErVerb" => VerbConjugation.ErVerb,
                "StrongErVerb" => VerbConjugation.StrongErVerb,
                "RVerb" => VerbConjugation.RVerb,
                "IrregularVerb" => VerbConjugation.IrregularVerb,
                _ => throw new InvalidEnumArgumentException()
            },
            Imperative = request.Imperative,
            PresentTense = request.PresentTense
        };

        switch (request.VerbConjugation)
        {
            case "StrongErVerb":
                verb.VowelChangeGroup = VowelChangeGroup.Five;
                break;
            case "IrregularVerb":
                verb.PastTense = request.PastTense;
                verb.Supine = request.Supine;
                break;
        }

        return verb;
            
    }
}