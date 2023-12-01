using Application.Contracts.Repos;
using MediatR;

namespace Application.Features.Nouns.Commands
{
    public class CreateNounCommandHandler : IRequestHandler<CreateNounCommand, Unit>
    {
        private readonly INounRepo _nounRepo;

        public CreateNounCommandHandler(INounRepo nounRepo)
        {
            _nounRepo = nounRepo;
        }
        public async Task<Unit> Handle(CreateNounCommand request, CancellationToken cancellationToken)
        {
            var noun = request.ToModel();

            await _nounRepo.CreateNounAsync(noun);

            return Unit.Value;
        }
    }
}
