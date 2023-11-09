using System.ComponentModel;
using Domain.Enums;

namespace Application.Dtos.Sentence.Output;

public static class CreateSentenceVerbOutputDtoExtensions
{
    public static CreateSentenceVerbOutputDto ToCreateSentenceVerbOutputDto(this Domain.Models.Words.Verb model)
    {
        return new CreateSentenceVerbOutputDto()
        {
            Id = model.Id,
            PresentTense = model.PresentTense,
            VerbConjugation = model.VerbConjugation switch
            {
                VerbConjugation.ArVerb => "ArVerb",
                VerbConjugation.ErVerb => "ErVerb",
                VerbConjugation.RVerb => "RVerb",
                VerbConjugation.StrongErVerb => "StrongErVerb",
                VerbConjugation.IrregularVerb => "IrregularVerb",
                _ => throw new InvalidEnumArgumentException()
            },
            DisplayForm = model.DisplayForm
        };
    }
}