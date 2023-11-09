namespace LanguageSkeleton.Api.Dtos.Noun;

public static class GetAllNounsOutputDtoExtensions
{
    public static GetAllNounsOutputDto ToDto(this Domain.Models.Words.Noun noun)
    {
        return new GetAllNounsOutputDto()
        {
            SingularForm = noun.SingularForm,
            Id = noun.Id
        };
    }
}