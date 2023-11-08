namespace LanguageSkeleton.Api.Dtos.Verb;

public static class GetVerbOutputDtoExtensions
{
    public static GetVerbOutputDto ToGetVerbOutputDto(this Domain.Models.Words.Verb model)
    {
        return new GetVerbOutputDto()
        {
            BaseForm = model.Infinitive,
            DisplayForm = !string.IsNullOrEmpty(model.DisplayForm)  ? model.DisplayForm : model.Infinitive,
            Id = model.Id
        };
    }
}