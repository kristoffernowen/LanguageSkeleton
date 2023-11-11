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
                    Imperative = "prata",
                    PresentTense = "pratar",
                    Id = "9bd47607 - 3e7d - 4780 - b4c4 - 0cf03e9167ad",
                    VerbConjugation = VerbConjugation.ArVerb
                },
                new()
                {
                    Imperative = "läs",
                    PresentTense = "läser",
                    Id = "8de87010 - 3a43 - 4a4e - 9361 - b15ee46bc62f",
                    VerbConjugation = VerbConjugation.ErVerb
                },
                new()
                {
                    Imperative = "kör",
                    PresentTense = "kör",
                    Id = "f30412a7 - 2a41 - 42f5 - 8194 - 831d5183043e",
                    VerbConjugation = VerbConjugation.ErVerb
                },
                new()
                {
                    Imperative = "bo",
                    PresentTense = "bor",
                    Id = "b86e5e92 - 960c - 42bf - bda8 - 9339529dd951",
                    VerbConjugation = VerbConjugation.RVerb
                },
                new()
                {
                    Imperative = "flyg",
                    PresentTense = "flyger",
                    Id = "601e8d14-6152-4a48-9065-0b6be35a8773",
                    VerbConjugation = VerbConjugation.StrongErVerb
                },
                new()
                {
                    Imperative = "gör",
                    Infinitive = "göra",
                    PresentTense = "gör",
                    PastTense = "gjorde",
                    Supine = "gjort",
                    Id = "64d55fee-b1c5-42e6-b4ab-d8365dc5a83d",
                    VerbConjugation = VerbConjugation.IrregularVerb
                }
            };

            var mockRepo = new Mock<IVerbRepo>();

            mockRepo.Setup(r => r.GetAllVerbAsync()).ReturnsAsync(verbs);

            mockRepo.Setup(r => r.GetVerbAsync(It.IsAny<string>())).ReturnsAsync((string id) => verbs.FirstOrDefault(x => x.Id == id)!);

            return mockRepo;
        }
    }
}
