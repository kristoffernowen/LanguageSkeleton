using Application.Contracts.Repos;
using MediatR;

namespace Application.Features.VerbActions.Queries.GetVerbById
{
    public class GetVerbByIdQueryHandler : IRequestHandler<GetVerbByIdQuery, GetVerbByIdDto>
    {
        private readonly IVerbRepo _verbRepo;

        public GetVerbByIdQueryHandler(IVerbRepo verbRepo)
        {
            _verbRepo = verbRepo;
        }
        public async Task<GetVerbByIdDto> Handle(GetVerbByIdQuery request, CancellationToken cancellationToken)
        {
            var verb = await _verbRepo.GetVerbAsync(request.Id);

            return verb.ToGetVerbByIdDto();
        }
    }
}
