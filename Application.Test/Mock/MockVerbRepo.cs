using Application.Contracts.Repos;
using Domain.Enums;
using Domain.Models.Words;
using Moq;

namespace Application.Test.Mock
{
    public class MockVerbRepo
    {
        public static Mock<IVerbRepo> GetVerbMockVerbRepo()
        {
           // var id = "";
            var verbs = new List<Verb>()
            {
                new()
                {
                    BaseForm = "prata",
                    Id = "9bd47607 - 3e7d - 4780 - b4c4 - 0cf03e9167ad",
                    VerbConjugation = VerbConjugation.ArVerb
                },
                new()
                {
                    BaseForm = "läsa",
                    Id = "8de87010 - 3a43 - 4a4e - 9361 - b15ee46bc62f",
                    VerbConjugation = VerbConjugation.ErVerb
                },
                new()
                {
                    BaseForm = "köra",
                    Id = "f30412a7 - 2a41 - 42f5 - 8194 - 831d5183043e",
                    VerbConjugation = VerbConjugation.ErVerb
                },
                new()
                {
                    BaseForm = "bo",
                    Id = "b86e5e92 - 960c - 42bf - bda8 - 9339529dd951",
                    VerbConjugation = VerbConjugation.RVerb
                }
            };

            var mockRepo = new Mock<IVerbRepo>();

            mockRepo.Setup(r => r.GetAllVerbAsync()).Returns(verbs);

            mockRepo.Setup(r => r.GetVerbAsync(It.IsAny<string>())).Returns((string id) => verbs.FirstOrDefault(x => x.Id == id)!);

            return mockRepo;
        }
    }
}
