using Core.Contracts.Repos;
using Core.Contracts.Services;
using Core.Models.Words;

namespace Application.Services
{
    public class VerbService : IVerbService
    {
        private readonly IVerbRepo _verbRepo;

        public VerbService(IVerbRepo verbRepo)
        {
            _verbRepo = verbRepo;
        }
        public void CreateVerb(Verb verb)
        {
            _verbRepo.CreateVerb(verb);
        }

        public List<Verb> GetAll()
        {
            return _verbRepo.GetAllVerb();
        }
    }
}
