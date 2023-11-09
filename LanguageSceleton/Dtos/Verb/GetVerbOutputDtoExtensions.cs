namespace LanguageSkeleton.Api.Dtos.Verb;

public static class GetVerbOutputDtoExtensions
{
    public static GetVerbOutputDto ToGetVerbOutputDto(this Domain.Models.Words.Verb model)
    {
        return new GetVerbOutputDto()
        {
            PresentTense = model.PresentTense,
            DisplayForm = !string.IsNullOrEmpty(model.DisplayForm)  ? model.DisplayForm : model.PresentTense,
            Id = model.Id
        };
    }
}