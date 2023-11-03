using System.ComponentModel;
using Domain.Enums;

namespace LanguageSkeleton.Api.Dtos.Sentence.Output;

public static class CreateSentenceVerbOutputDtoExtensions
{
    public static CreateSentenceVerbOutputDto ToCreateSentenceVerbOutputDto(this Domain.Models.Words.Verb model)
    {
        return new CreateSentenceVerbOutputDto()
        {
            Id = model.Id,
            BaseForm = model.BaseForm,
            VerbConjugation = model.VerbConjugation switch
            {
                VerbConjugation.ArVerb => "ArVerb",
                VerbConjugation.ErVerb => "ErVerb",
                VerbConjugation.RVerb => "RVerb",
                VerbConjugation.StrongErVerb => "StrongErVerb",
                _ => throw new InvalidEnumArgumentException()
            },
            DisplayForm = model.DisplayForm
        };
    }
}