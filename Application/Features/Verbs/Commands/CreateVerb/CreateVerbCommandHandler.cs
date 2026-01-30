using Application.Contracts.Repos;
using MediatR;

namespace Application.Features.Verbs.Commands.CreateVerb
{
    public class CreateVerbCommandHandler(IVerbRepo verbRepo) : IRequestHandler<CreateVerbCommand, Unit>
    {
        public async Task<Unit> Handle(CreateVerbCommand request, CancellationToken cancellationToken)
        {
            var verb = request.ToModel();

            await verbRepo.CreateAsync(verb);

            return Unit.Value;
        }
    }
}
