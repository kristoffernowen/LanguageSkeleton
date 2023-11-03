using System.ComponentModel;
using Domain.Enums;

namespace LanguageSkeleton.Api.Dtos.Sentence.Input;

public static class CreateSentenceNounInputDtoExtensions
{
    public static Domain.Models.Words.Noun ToModel(this CreateSentenceNounInputDto inputDto)
    {
        return new Domain.Models.Words.Noun()
        {
            Id = inputDto.Id,
            Definiteness = inputDto.Definiteness switch
            {
                "definite" => Definiteness.Definite,
                "indefinite" => Definiteness.Indefinite,
                _ => throw new InvalidEnumArgumentException()
            },
            GrammaticalNumber = inputDto.GrammaticalNumber switch
            {
                "singular" => GrammaticalNumber.Singular,
                "plural" => GrammaticalNumber.Plural,
                _ => throw new InvalidEnumArgumentException()
            }
        };
    }
}