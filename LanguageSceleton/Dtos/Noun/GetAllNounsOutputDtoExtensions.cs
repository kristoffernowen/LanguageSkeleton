namespace LanguageSceleton.Api.Dtos.Noun;

public static class GetAllNounsOutputDtoExtensions
{
    public static GetAllNounsOutputDto ToDto(this Core.Models.Words.Noun noun)
    {
        return new GetAllNounsOutputDto()
        {
            BaseForm = noun.BaseForm,
            Id = noun.Id
        };
    }
}