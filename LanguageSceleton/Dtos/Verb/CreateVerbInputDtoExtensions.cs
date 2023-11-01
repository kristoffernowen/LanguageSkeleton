using System.ComponentModel;
using Domain.Enums;

namespace LanguageSkeleton.Api.Dtos.Verb;

public static class CreateVerbInputDtoExtensions
{
    public static Domain.Models.Words.Verb ToModel(this CreateVerbInputDto dto)
    {
        var verb = new Domain.Models.Words.Verb
        {
            BaseForm = dto.BaseForm,
            VerbConjugation = dto.VerbConjugation switch
            {
                "ArVerb" => VerbConjugation.ArVerb,
                "ErVerb" => VerbConjugation.ErVerb,
                "StrongErVerb" => VerbConjugation.StrongErVerb,
                "RVerb" => VerbConjugation.RVerb,
                _ => throw new InvalidEnumArgumentException()
            }
        };
        return verb;
    }
}