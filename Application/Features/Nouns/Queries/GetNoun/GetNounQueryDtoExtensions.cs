using System.ComponentModel;
using Domain.Enums;

namespace Application.Features.Nouns.Queries.GetNoun;

public static class GetNounQueryDtoExtensions
{
    public static GetNounQueryDto ToNounQueryDto(this Domain.Models.Words.Noun model)
    {
        var dto = new GetNounQueryDto()
        {
            SingularForm = model.SingularForm,
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
                GrammaticalNumber.Plural => "plural",
                _ => throw new InvalidEnumArgumentException()
            };
        }

        return dto;
    }
}