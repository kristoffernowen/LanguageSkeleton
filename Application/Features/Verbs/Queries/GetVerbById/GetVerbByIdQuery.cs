using MediatR;

namespace Application.Features.Verbs.Queries.GetVerbById
{
    public record GetVerbByIdQuery(string Id) : IRequest<GetVerbByIdDto>;
}
