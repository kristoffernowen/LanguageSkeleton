using Application.Services.NounForms;
using Application.Test.Mock;
using Core.Contracts.Repos;
using Core.Contracts.Services.Noun;
using Core.Enums;
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
        public void ShouldReturnDeclensionOneDefinitiveSingular()
        {
            var girl = _mockRepo.Object.GetNoun("495a642f-c518-4b31-a91f-5586a0221694");
            girl.GrammaticalNumber = GrammaticalNumber.Singular;
            girl = _definitenessService.Definite(girl);

            Assert.Equal("flickan", girl.DisplayForm);
        }
        
        [Fact]
        public void ShouldReturnDeclensionOneIndefiniteSingular()
        {
            var girl = _mockRepo.Object.GetNoun("495a642f-c518-4b31-a91f-5586a0221694");
            girl.GrammaticalNumber = GrammaticalNumber.Singular;
            girl = _definitenessService.Indefinite(girl);

            Assert.Equal("flicka", girl.DisplayForm);
        }

        [Fact]
        public void ShouldReturnDeclensionOneDefinitivePlural()
        {
            var girl = _mockRepo.Object.GetNoun("495a642f-c518-4b31-a91f-5586a0221694");
            girl.GrammaticalNumber = GrammaticalNumber.Plural;
            girl = _definitenessService.Definite(girl);

            Assert.Equal("flickorna", girl.DisplayForm);
        }

        [Fact]
        public void ShouldReturnDeclensionFiveDefinitiveSingular()
        {
            var house = _mockRepo.Object.GetNoun("2c893003-26df-409d-b85f-15b2f251dd9d");
            house.GrammaticalNumber = GrammaticalNumber.Singular;
            house = _definitenessService.Definite(house);

            Assert.Equal("huset", house.DisplayForm);
        }
        [Fact]
        public void ShouldReturnDeclensionFiveDefinitivePlural()
        {
            var house = _mockRepo.Object.GetNoun("2c893003-26df-409d-b85f-15b2f251dd9d");
            house.GrammaticalNumber = GrammaticalNumber.Plural;
            house = _definitenessService.Definite(house);

            Assert.Equal("husen", house.DisplayForm);
        }
    }
}
