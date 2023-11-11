using System.ComponentModel;
using Domain.Enums;
using Domain.Models.Sentence;

namespace Application.Features.BasicSentence.Queries.DisplayBasicSentence;

public static class DisplayBasicSentenceDtoExtensions
{
    public static DisplayBasicSentenceDto ToDto(this Sentence model)
    {
        return new DisplayBasicSentenceDto()
        {
            Tense = model.Tense switch
            {
                Tense.Present => "present",
                Tense.Perfect => "perfect",
                Tense.Future => "future",
                Tense.Past => "past",
                _ => throw new InvalidEnumArgumentException()
            },
            StatementOrQuestion = model.StatementOrQuestion switch
            {
                StatementOrQuestion.Statement => "statement",
                StatementOrQuestion.Question => "question",
                _ => throw new InvalidEnumArgumentException()
            },
            DisplaySentence = model.DisplaySentence,
            SubjectId = model.SubjectNoun.Id,
            SubjectDisplayForm = model.SubjectNoun.DisplayForm,
            SubjectDefiniteness = model.SubjectNoun.Definiteness switch
            {
                Definiteness.Definite => "definite",
                Definiteness.Indefinite => "indefinite",
                _ => throw new InvalidEnumArgumentException()
            },
            SubjectGrammaticalNumber = model.SubjectNoun.GrammaticalNumber switch
            {
                GrammaticalNumber.Singular => "singular",
                GrammaticalNumber.Plural => "plural",
                _ => throw new InvalidEnumArgumentException()
            },
            PredicateId = model.Predicate.Id,
            PredicateDisplayForm = model.Predicate.DisplayForm,
            PredicatePresentTense = model.Predicate.PresentTense,
            PredicateVerbConjugation = model.Predicate.VerbConjugation switch
            {
                VerbConjugation.ArVerb => "ArVerb",
                VerbConjugation.ErVerb => "ErVerb",
                VerbConjugation.RVerb => "RVerb",
                VerbConjugation.StrongErVerb => "StrongErVerb",
                VerbConjugation.IrregularVerb => "IrregularVerb",
                _ => throw new InvalidEnumArgumentException()
            },

        };
    }
}