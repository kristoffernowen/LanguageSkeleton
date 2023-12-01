using MediatR;

namespace Application.Features.VerbActions.Queries.GetVerbs
{
    public class GetVerbQuery : IRequest<List<GetVerbQueryDto>>
    {
    }
}
