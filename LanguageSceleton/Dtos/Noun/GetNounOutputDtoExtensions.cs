using System.ComponentModel;
using Domain.Enums;

namespace LanguageSkeleton.Api.Dtos.Noun;

public static class GetNounOutputDtoExtensions
{
    public static GetNounOutputDto ToNounOutputDto(this Domain.Models.Words.Noun model)
    {
        var dto = new GetNounOutputDto()
        {
            BaseForm = model.BaseForm,
            DisplayForm = model.DisplayForm!,
            Id = model.Id
        };

        if (model.Definiteness != null)
        {
            dto.Definiteness = model.Definiteness switch
            {
                Definiteness.Definite => "definite",
                Definiteness.Indefinite => "indefinite",
                _ => throw new InvalidEnumArgumentException()
            };
        }

        if (dto.GrammaticalNumber != null)
        {
            dto.GrammaticalNumber = model.GrammaticalNumber switch
            {
                GrammaticalNumber.Singular => "singular",
                GrammaticalNumber.Plural => "plural"
            };
        }

        return dto;
    }
}