using Application.Contracts.Repos;
using Domain.Enums.Noun;
using Domain.Models.ValueObjects;
using Moq;

namespace Application.Test.Mock;

public class MockNounRepo
{
    public static Mock<INounRepo> GetMockNounRepo()
    {
        var nouns = new List<Noun>
        {
            new()
            {
                Id = "495a642f-c518-4b31-a91f-5586a0221694",
                SingularForm = "flicka",
                PluralForm = "flickor",
                NounArticle = NounArticle.en,
                NounDeclension = NounDeclension.One,
                GrammaticalGender = GrammaticalGender.Feminine
            },
            new()
            {
                Id = "2c893003-26df-409d-b85f-15b2f251dd9d",
                SingularForm = "hus",
                PluralForm = "hus",
                NounArticle = NounArticle.ett,
                NounDeclension = NounDeclension.Five,
                GrammaticalGender = GrammaticalGender.Neuter
            }
        };

        var mockRepo = new Mock<INounRepo>();
        mockRepo.Setup (r =>  r.GetAllNounsAsync()).ReturnsAsync(nouns);
        mockRepo.Setup(r => r.GetNounAsync(It.IsAny<string>()))
            .ReturnsAsync((string id) => nouns.FirstOrDefault(x => x.Id == id)!);

        return mockRepo;
    }
}