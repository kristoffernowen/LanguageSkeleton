using Application.Contracts.Repos;
using Application.Contracts.Services.Noun;
using Application.Contracts.Services.Verb;
using Domain.Models.Words;
using Moq;

namespace Application.Test.Mock
{
    public class VerbServiceFake : IVerbService
    {
        private readonly Mock<IVerbRepo> _mockRepo;

        public VerbServiceFake()
        {
            _mockRepo = MockVerbRepo.GetVerbMockVerbRepo();
        }

        public Task CreateVerbAsync(Verb verb)
        {
            throw new NotImplementedException();
        }

        public Task<List<Verb>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Verb> GetAsync(string id)
        {
            return await _mockRepo.Object.GetVerbAsync(id);
        }

        public async Task<Verb> GetByPresentTense(string presentTense)
        {
            return await _mockRepo.Object.GetVerbFromPresentTenseAsync(presentTense);
        }
    }
}
