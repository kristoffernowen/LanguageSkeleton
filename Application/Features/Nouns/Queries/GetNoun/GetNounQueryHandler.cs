using Application.Contracts.Repos;
using MediatR;

namespace Application.Features.Nouns.Queries.GetNoun
{
    public class GetNounQueryHandler : IRequestHandler<GetNounQuery, GetNounQueryDto>
    {
        private readonly INounRepo _nounRepo;

        public GetNounQueryHandler(INounRepo nounRepo)
        {
            _nounRepo = nounRepo;
        }
        public async Task<GetNounQueryDto> Handle(GetNounQuery request, CancellationToken cancellationToken)
        {
            var noun = await _nounRepo.GetNounAsync(request.Id);

            return noun.ToNounQueryDto();
        }
    }
}
