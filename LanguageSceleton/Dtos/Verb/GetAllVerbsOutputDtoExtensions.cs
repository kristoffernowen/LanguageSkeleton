namespace LanguageSceleton.Api.Dtos.Verb;

public static class GetAllVerbsOutputDtoExtensions
{
    public static GetAllVerbsOutputDto ToDto(this Core.Models.Words.Verb verb)
    {
        return new GetAllVerbsOutputDto()
        {
            BaseForm = verb.BaseForm,
            Id = verb.Id
        };
    }
}