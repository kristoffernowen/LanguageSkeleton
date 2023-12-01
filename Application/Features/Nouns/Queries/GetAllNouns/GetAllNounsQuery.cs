using MediatR;

namespace Application.Features.Nouns.Queries.GetAllNouns
{
    public record GetAllNounsQuery : IRequest<List<GetAllNounsQueryDto>>;
}
