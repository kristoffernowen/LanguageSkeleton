using System.ComponentModel;
using Domain.Enums;

namespace LanguageSkeleton.Api.Dtos.Verb;

public static class CreateVerbInputDtoExtensions
{
    public static Domain.Models.Words.Verb ToModel(this CreateVerbInputDto dto)
    {
        var verb = new Domain.Models.Words.Verb
        {
            Infinitive = dto.Infinitive,
            VerbConjugation = dto.VerbConjugation switch
            {
                "ArVerb" => VerbConjugation.ArVerb,
                "ErVerb" => VerbConjugation.ErVerb,
                "StrongErVerb" => VerbConjugation.StrongErVerb,
                "RVerb" => VerbConjugation.RVerb,
                "IrregularVerb" => VerbConjugation.IrregularVerb,
                _ => throw new InvalidEnumArgumentException()
            },
            Imperative = dto.Imperative,
            PresentTense = dto.PresentTense
        };

        switch (dto.VerbConjugation)
        {
            case "StrongErVerb":
                verb.VowelChangeGroup = VowelChangeGroup.Five;
                break;
            case "IrregularVerb":
                verb.PastTense = dto.PastTense;
                verb.Supine = dto.Supine;
                break;
        }

        return verb;
    }
}