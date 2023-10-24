using System.ComponentModel;
using Core.Enums;

namespace LanguageSceleton.Api.Dtos.Verb;

public static class CreateVerbInputDtoExtensions
{
    public static Core.Models.Words.Verb ToModel(this CreateVerbInputDto dto)
    {
        var verb = new Core.Models.Words.Verb
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