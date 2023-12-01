using MediatR;

namespace Application.Features.Nouns.Queries.GetNoun
{
    public record GetNounQuery(string Id) : IRequest<GetNounQueryDto>;
}
