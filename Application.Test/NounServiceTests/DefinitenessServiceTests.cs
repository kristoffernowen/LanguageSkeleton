using Application.Contracts.Repos;
using Application.Contracts.Services.Noun;
using Application.Services.NounForms;
using Application.Test.Mock;
using Domain.Enums;
using Moq;

namespace Application.Test.NounServiceTests
{
    public class DefinitenessServiceTests
    {
        private readonly Mock<INounRepo> _mockRepo;
        private readonly IDefinitenessService _definitenessService = new DefinitenessService();

        public DefinitenessServiceTests()
        {
            _mockRepo = MockNounRepo.GetMockNounRepo();
        }

        [Fact]
        public async void ShouldReturnDeclensionOneDefinitiveSingular()
        {
            var girl = await _mockRepo.Object.GetNounAsync("495a642f-c518-4b31-a91f-5586a0221694");
            girl.GrammaticalNumber = GrammaticalNumber.Singular;
            girl = _definitenessService.Definite(girl);

            Assert.Equal("flickan", girl.DisplayForm);
        }
        
        [Fact]
        public async void ShouldReturnDeclensionOneIndefiniteSingular()
        {
            var girl = await _mockRepo.Object.GetNounAsync("495a642f-c518-4b31-a91f-5586a0221694");
            girl.GrammaticalNumber = GrammaticalNumber.Singular;
            girl = _definitenessService.Indefinite(girl);

            Assert.Equal("flicka", girl.DisplayForm);
        }

        [Fact]
        public async void ShouldReturnDeclensionOneDefinitivePlural()
        {
            var girl = await _mockRepo.Object.GetNounAsync("495a642f-c518-4b31-a91f-5586a0221694");
            girl.GrammaticalNumber = GrammaticalNumber.Plural;
            girl = _definitenessService.Definite(girl);

            Assert.Equal("flickorna", girl.DisplayForm);
        }

        [Fact]
        public async void ShouldReturnDeclensionFiveDefinitiveSingular()
        {
            var house = await _mockRepo.Object.GetNounAsync("2c893003-26df-409d-b85f-15b2f251dd9d");
            house.GrammaticalNumber = GrammaticalNumber.Singular;
            house = _definitenessService.Definite(house);

            Assert.Equal("huset", house.DisplayForm);
        }
        [Fact]
        public async void ShouldReturnDeclensionFiveDefinitivePlural()
        {
            var house = await _mockRepo.Object.GetNounAsync("2c893003-26df-409d-b85f-15b2f251dd9d");
            house.GrammaticalNumber = GrammaticalNumber.Plural;
            house = _definitenessService.Definite(house);

            Assert.Equal("husen", house.DisplayForm);
        }
    }
}
