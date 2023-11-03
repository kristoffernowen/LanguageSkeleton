using Domain.Contracts.Repos;
using Domain.Contracts.Services.Verb;
using Domain.Models.Words;

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

        public Verb Get(string id)
        {
            return _verbRepo.GetVerb(id);
        }
    }
}
