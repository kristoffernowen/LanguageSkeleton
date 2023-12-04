namespace Application.Features.Verbs.Queries.GetVerbById;

public static class GetVerbByIdDtoExtensions
{
    public static GetVerbByIdDto ToGetVerbByIdDto(this Domain.Models.Words.Verb model)
    {
        return new GetVerbByIdDto()
        {
            PresentTense = model.PresentTense,
            DisplayForm = !string.IsNullOrEmpty(model.DisplayForm) ? model.DisplayForm : model.PresentTense,
            Id = model.Id
        };
    }
}