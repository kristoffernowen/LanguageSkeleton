using Domain.Models.ValueObjects;

namespace Application.Features.Nouns.Queries.GetNoun;

public static class GetNounQueryDtoExtensions
{
    public static GetNounQueryDto ToNounQueryDto(this Noun model)
    {
        var dto = new GetNounQueryDto()
        {
            SingularForm = model.SingularForm,
            DisplayForm = model.DisplayForm!,
            Id = model.Id
        };

        return dto;
    }
}