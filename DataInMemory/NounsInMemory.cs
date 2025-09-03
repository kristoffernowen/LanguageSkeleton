using Domain.Enums;
using Domain.Models.Words;

namespace DataInMemory
{
    internal static class NounsInMemory
    {
        public static List<Noun> Nouns { get; set; } = new List<Noun>
        {
            new Noun()
            {
                DisplayForm = "pojke",
                NounArticle = NounArticle.en,
                PluralForm = "pojkar",
                SingularForm = "pojke",
                Id = "11c8d87b-c8c1-456f-a523-f82a656caaaf"
            }
        };
    }

    public static class VerbsInMemory
    {
        public static List<Verb> Verbs { get; set; } = new List<Verb>
        {
            new()
            {
                Id = "3d8fa3a8-689d-42ff-ae6f-3b7b2ffdb671",
                Imperative = "prata",
                PresentTense = "pratar",
                VerbConjugation = VerbConjugation.ArVerb,

            }
        };
    }
}
