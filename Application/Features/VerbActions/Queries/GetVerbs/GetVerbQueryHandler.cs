using Application.Contracts.Repos;
using MediatR;

namespace Application.Features.VerbActions.Queries.GetVerbs
{
    public class GetVerbQueryHandler : IRequestHandler<GetVerbQuery, List<GetVerbQueryDto>>
    {
        private readonly IVerbRepo _verbRepo;

        public GetVerbQueryHandler(IVerbRepo verbRepo)
        {
            _verbRepo = verbRepo;
        }

        public async Task<List<GetVerbQueryDto>> Handle(GetVerbQuery request, CancellationToken cancellationToken)
        {
            var verbs = await _verbRepo.GetAllVerbAsync();

            return verbs.Select(v => v.ToGetVerbQueryDto()).ToList();
        }
    }
}
