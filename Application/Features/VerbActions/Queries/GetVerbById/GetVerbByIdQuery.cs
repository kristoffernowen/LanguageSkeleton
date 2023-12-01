using MediatR;

namespace Application.Features.VerbActions.Queries.GetVerbById
{
    public record GetVerbByIdQuery(string Id) : IRequest<GetVerbByIdDto>;
}
