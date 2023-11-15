using Application.Contracts.Repos;
using Application.Contracts.Services.Verb;
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
        public async Task CreateVerbAsync(Verb verb)
        {
            await _verbRepo.CreateVerbAsync(verb);
        }

        public async Task<List<Verb>> GetAllAsync()
        {
            return await _verbRepo.GetAllVerbAsync();
        }

        public async Task<Verb> GetAsync(string id)
        {
            return await _verbRepo.GetVerbAsync(id);
        }

        public async Task<Verb> GetByPresentTense(string presentTense)
        {
            return await _verbRepo.GetVerbFromPresentTenseAsync(presentTense);
        }
    }
}
