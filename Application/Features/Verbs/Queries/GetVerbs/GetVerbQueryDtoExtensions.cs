namespace Application.Features.Verbs.Queries.GetVerbs
{
    public static class GetVerbQueryDtoExtensions
    {
        public static GetVerbQueryDto ToGetVerbQueryDto(this Domain.Models.Words.Verb model)
        {
            return new GetVerbQueryDto()
            {
                PresentTense = model.PresentTense,
                Id = model.Id
            };
        }
    }
}
