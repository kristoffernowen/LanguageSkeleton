using System.ComponentModel;
using Application.Services.NounForms;
using Definiteness = Domain.Enums.Definiteness;
using GrammaticalNumber = Domain.Enums.GrammaticalNumber;

namespace Application.Dtos.Sentence.Input;

public static class CreateSentenceNounInputDtoExtensions
{
    public static Domain.Models.Words.Noun ToModel(this CreateSentenceNounInputDto inputDto)
    {
        return new Domain.Models.Words.Noun(new NounDisplayFormSetter())
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