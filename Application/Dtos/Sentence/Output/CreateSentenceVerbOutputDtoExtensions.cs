using System.ComponentModel;
using Domain.Enums.Verb;

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
                VerbConjugation.WeakOne => "ArVerb",
                VerbConjugation.WeakTwo => "ErVerb",
                VerbConjugation.WeakThree => "RVerb",
                VerbConjugation.StrongFour => "StrongErVerb",
                VerbConjugation.Irregular => "IrregularVerb",
                _ => throw new InvalidEnumArgumentException()
            },
            DisplayForm = model.DisplayForm
        };
    }
}