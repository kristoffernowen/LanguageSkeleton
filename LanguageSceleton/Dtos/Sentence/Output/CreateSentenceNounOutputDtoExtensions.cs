using System.ComponentModel;
using Domain.Enums;

namespace LanguageSkeleton.Api.Dtos.Sentence.Output;

public static class CreateSentenceNounOutputDtoExtensions
{
    public static CreateSentenceNounOutputDto ToSentenceNounOutputDto(this Domain.Models.Words.Noun model)
    {
        return new ()
        {
            Id = model.Id,
            Definiteness = model.Definiteness switch
            {
                Definiteness.Definite => "definite",
                Definiteness.Indefinite => "indefinite",
                _ => throw new InvalidEnumArgumentException()
            },
            GrammaticalNumber = model.GrammaticalNumber switch
            {
                GrammaticalNumber.Singular => "singular",
                GrammaticalNumber.Plural => "plural",
                _ => throw new InvalidEnumArgumentException()
            },
            DisplayForm = model.DisplayForm
        };
    }
}