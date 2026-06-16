using Domain.Models.ValueObjects;

namespace Application.Features.Nouns.Queries.GetAllNouns;

public static class GetAllNounsQueryExtensions
{
    public static GetAllNounsQueryDto ToGetAllNounsQueryDto(this Noun noun)
    {
        return new GetAllNounsQueryDto()
        {
            SingularForm = noun.SingularForm,
            Id = noun.Id
        };
    }
}