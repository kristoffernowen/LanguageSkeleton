using Application.Contracts.Repos;
using MediatR;

namespace Application.Features.Nouns.Queries.GetAllNouns
{
    public class GetAllNounsQueryHandler : IRequestHandler<GetAllNounsQuery, List<GetAllNounsQueryDto>>
    {
        private readonly INounRepo _nounRepo;


        public GetAllNounsQueryHandler(INounRepo nounRepo)
        {
            _nounRepo = nounRepo;
        }
        public async Task<List<GetAllNounsQueryDto>> Handle(GetAllNounsQuery request, CancellationToken cancellationToken)
        {
            var nouns = await _nounRepo.GetAllNounsAsync();

            return nouns.Select(n => n.ToGetAllNounsQueryDto()).ToList();
        }
    }
}
