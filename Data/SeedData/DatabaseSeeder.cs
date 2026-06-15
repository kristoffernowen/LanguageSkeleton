using AutoMapper;
using Data.PersistenceEntities;
using Domain.Enums.Noun;
using Domain.Enums.Verb;
using Domain.Models.Words;

namespace Data.SeedData;

public static class DatabaseSeeder
{
    public static void SeedVerbs(SqlContext context, IMapper mapper)
    {
        if (context.Verbs.Any())
            return;

        var verbs = new List<VerbEntity>
        {
            new VerbEntity
            {
                Id = "8e87ea09-a6bf-431c-9559-b5221b14e81b",
                Infinitive = "ha",
                Imperative = "ha",
                PresentTense = "har",
                PastTense = "hade",
                Supine = "haft",
                VerbConjugation = VerbConjugation.Irregular
            },
            new VerbEntity()
            {
                Id = "3c9d5f4e-2b6a-4f8e-9c3d-1e2f3a4b5c6d",
                Infinitive = "skola",
                Imperative = VerbConstants.NotApplicable,
                PresentTense = "ska",
                PastTense = "skulle",
                Supine = "skolat",
                VerbConjugation = VerbConjugation.Irregular
            },
            new VerbEntity()
            {
                Id = "78901234-5f67-890a-bcde-f1234567890a",
                Infinitive = "vara",
                Imperative = "var",
                PresentTense = "är",
                PastTense = "var",
                Supine = "varit",
                VerbConjugation = VerbConjugation.Irregular
            },
            new VerbEntity
            {
                Id = Guid.NewGuid().ToString(),
                Infinitive = "prata",
                Imperative = "prata",
                PresentTense = "pratar",
                PastTense = "pratade",
                Supine = "pratat",
                VerbConjugation = VerbConjugation.WeakOne
            },
            new VerbEntity
            {
                Id = Guid.NewGuid().ToString(),
                Infinitive = "titta",
                Imperative = "titta",
                PresentTense = "tittar",
                PastTense = "tittade",
                Supine = "tittat",
                VerbConjugation = VerbConjugation.WeakOne
            },
            new VerbEntity
            {
                Id = Guid.NewGuid().ToString(),
                Infinitive = "äta",
                Imperative = "ät",
                PresentTense = "äter",
                PastTense = "åt",
                Supine = "ätit",
                VerbConjugation = VerbConjugation.StrongFour
            },
            new VerbEntity
            {
                Id = Guid.NewGuid().ToString(),
                Infinitive = "dricka",
                Imperative = "drick",
                PresentTense = "dricker",
                PastTense = "drack",
                Supine = "druckit",
                VerbConjugation = VerbConjugation.StrongFour
            },
            new VerbEntity
            {
                Id = Guid.NewGuid().ToString(),
                Infinitive = "sova",
                Imperative = "sov",
                PresentTense = "sover",
                PastTense = "sov",
                Supine = "sovit",
                VerbConjugation = VerbConjugation.StrongFour
            },
            new VerbEntity
            {
                Id = Guid.NewGuid().ToString(),
                Infinitive = "springa",
                Imperative = "spring",
                PresentTense = "springer",
                PastTense = "sprang",
                Supine = "sprungit",
                VerbConjugation = VerbConjugation.StrongFour
            },
            new VerbEntity
            {
                Id = Guid.NewGuid().ToString(),
                Infinitive = "skriva",
                Imperative = "skriv",
                PresentTense = "skriver",
                PastTense = "skrev",
                Supine = "skrivit",
                VerbConjugation = VerbConjugation.StrongFour
            },
            new VerbEntity
            {
                Id = Guid.NewGuid().ToString(),
                Infinitive = "ljuga",
                Imperative = "ljug",
                PresentTense = "ljuger",
                PastTense = "ljög",
                Supine = "ljugit",
                VerbConjugation = VerbConjugation.StrongFour
            },
            new VerbEntity
            {
                Id = Guid.NewGuid().ToString(),
                Infinitive = "flyga",
                Imperative = "flyg",
                PresentTense = "flyger",
                PastTense = "flög",
                Supine = "flugit",
                VerbConjugation = VerbConjugation.StrongFour
            },
            new VerbEntity
            {
                Id = Guid.NewGuid().ToString(),
                Infinitive = "simma",
                Imperative = "simma",
                PresentTense = "simmar",
                PastTense = "simmade",
                Supine = "simmat",
                VerbConjugation = VerbConjugation.WeakOne
            }
        };

        context.Verbs.AddRange(verbs);
        context.SaveChanges();
    }

    public static void SeedNouns(SqlContext context, IMapper mapper)
    {
        if (context.Nouns.Any())
            return;

        var nouns = new List<NounEntity>
        {
            new NounEntity
            {
                Id = Guid.NewGuid().ToString(),
                SingularForm = "pojke",
                PluralForm = "pojkar",
                NounDeclension = NounDeclension.Two,
                NounArticle = NounArticle.en,
                GrammaticalGender = GrammaticalGender.CommonGender
            },
            new NounEntity
            {
                Id = Guid.NewGuid().ToString(),
                SingularForm = "flicka",
                PluralForm = "flickor",
                NounDeclension = NounDeclension.One,
                NounArticle = NounArticle.en,
                GrammaticalGender = GrammaticalGender.CommonGender
            },
            new NounEntity
            {
                Id = Guid.NewGuid().ToString(),
                SingularForm = "fågel",
                PluralForm = "fåglar",
                NounDeclension = NounDeclension.Two,
                NounArticle = NounArticle.en,
                GrammaticalGender = GrammaticalGender.CommonGender
            },
            new NounEntity
            {
                Id = Guid.NewGuid().ToString(),
                SingularForm = "hund",
                PluralForm = "hundar",
                NounDeclension = NounDeclension.Two,
                NounArticle = NounArticle.en,
                GrammaticalGender = GrammaticalGender.CommonGender
            },
            new NounEntity
            {
                Id = Guid.NewGuid().ToString(),
                SingularForm = "katt",
                PluralForm = "katter",
                NounDeclension = NounDeclension.Three,
                NounArticle = NounArticle.en,
                GrammaticalGender = GrammaticalGender.CommonGender
            },
            new NounEntity
            {
                Id = Guid.NewGuid().ToString(),
                SingularForm = "man",
                PluralForm = "män",
                NounDeclension = NounDeclension.Three,
                NounArticle = NounArticle.en,
                GrammaticalGender = GrammaticalGender.CommonGender
            },
            new NounEntity
            {
                Id = Guid.NewGuid().ToString(),
                SingularForm = "kvinna",
                PluralForm = "kvinnor",
                NounDeclension = NounDeclension.One,
                NounArticle = NounArticle.en,
                GrammaticalGender = GrammaticalGender.CommonGender
            },
            new NounEntity
            {
                Id = Guid.NewGuid().ToString(),
                SingularForm = "barn",
                PluralForm = "barn",
                NounDeclension = NounDeclension.Five,
                NounArticle = NounArticle.ett,
                GrammaticalGender = GrammaticalGender.Neuter
            },
            new NounEntity
            {
                Id = Guid.NewGuid().ToString(),
                SingularForm = "pirat",
                PluralForm = "pirater",
                NounDeclension = NounDeclension.Three,
                NounArticle = NounArticle.en,
                GrammaticalGender = GrammaticalGender.CommonGender
            },
            new NounEntity
            {
                Id = Guid.NewGuid().ToString(),
                SingularForm = "pilot",
                PluralForm = "piloter",
                NounDeclension = NounDeclension.Three,
                NounArticle = NounArticle.en,
                GrammaticalGender = GrammaticalGender.CommonGender
            }
        };

        context.Nouns.AddRange(nouns);
        context.SaveChanges();
    }
}
