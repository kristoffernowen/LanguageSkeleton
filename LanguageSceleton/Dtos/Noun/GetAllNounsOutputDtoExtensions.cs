namespace LanguageSkeleton.Api.Dtos.Noun;

public static class GetAllNounsOutputDtoExtensions
{
    public static GetAllNounsOutputDto ToDto(this Domain.Models.Words.Noun noun)
    {
        return new GetAllNounsOutputDto()
        {
            BaseForm = noun.BaseForm,
            Id = noun.Id
        };
    }
}