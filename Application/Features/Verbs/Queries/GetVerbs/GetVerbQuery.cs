using MediatR;

namespace Application.Features.Verbs.Queries.GetVerbs
{
    public class GetVerbQuery : IRequest<List<GetVerbQueryDto>>
    {
    }
}
