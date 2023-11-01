namespace LanguageSkeleton.Api.Dtos.Verb;

public static class GetAllVerbsOutputDtoExtensions
{
    public static GetAllVerbsOutputDto ToDto(this Domain.Models.Words.Verb verb)
    {
        return new GetAllVerbsOutputDto()
        {
            BaseForm = verb.BaseForm,
            Id = verb.Id
        };
    }
}