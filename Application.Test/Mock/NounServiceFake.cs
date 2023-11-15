using Application.Contracts.Repos;
using Application.Contracts.Services.Noun;
using Domain.Models.Words;
using Moq;
using System.ComponentModel;

namespace Application.Test.Mock
{
    public class NounServiceFake : INounService
    {
        private readonly Mock<INounRepo> _mockRepo;
        public NounServiceFake()
        {
            _mockRepo = MockNounRepo.GetMockNounRepo();
        }
        public Task CreateNounAsync(Noun noun)
        {
            throw new NotImplementedException();
        }

        public Task<List<Noun>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Noun> GetAsync(string id)
        {
            return await _mockRepo.Object.GetNounAsync(id);
        }

        public Noun GrammaticalNumberDisplayForm(Noun noun)
        {
            noun.DisplayForm = noun.GrammaticalNumber switch
            {
                Domain.Enums.GrammaticalNumber.Singular => noun.SingularForm,
                Domain.Enums.GrammaticalNumber.Plural => noun.PluralForm,
                _ => throw new InvalidEnumArgumentException()
            };

            return noun;
        }
    }
}
