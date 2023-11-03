namespace LanguageSkeleton.Api.Dtos.Verb;

public static class GetVerbOutputDtoExtensions
{
    public static GetVerbOutputDto ToGetVerbOutputDto(this Domain.Models.Words.Verb model)
    {
        return new GetVerbOutputDto()
        {
            BaseForm = model.BaseForm,
            DisplayForm = !string.IsNullOrEmpty(model.DisplayForm)  ? model.DisplayForm : model.BaseForm,
            Id = model.Id
        };
    }
}