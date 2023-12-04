using Application.Contracts.Repos;
using MediatR;

namespace Application.Features.Verbs.Commands.CreateVerb
{
    public class CreateVerbCommandHandler : IRequestHandler<CreateVerbCommand, Unit>
    {
        private readonly IVerbRepo _verbRepo;

        public CreateVerbCommandHandler(IVerbRepo verbRepo)
        {
            _verbRepo = verbRepo;
        }
        public async Task<Unit> Handle(CreateVerbCommand request, CancellationToken cancellationToken)
        {
            var verb = request.ToModel();

            await _verbRepo.CreateVerbAsync(verb);

            return Unit.Value;
        }
    }
}
