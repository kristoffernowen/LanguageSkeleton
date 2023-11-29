using System.ComponentModel;
using Application.Services.VerbTenses;
using Domain.Enums;
using Domain.Models.Sentence;
using Domain.Models.Words;

namespace Application.Features.BasicSentence.Queries.DisplayBasicSentence;

public static class DisplayBasicSentenceQueryExtensions
{
    public static Sentence ToSentence(this DisplayBasicSentenceQuery request, Noun subjectNoun, Verb predicate)
    {
        var sentence = new Sentence();
        subjectNoun.GrammaticalNumber = request.SubjectGrammaticalNumber switch
        {
            "singular" => GrammaticalNumber.Singular,
            "plural" => GrammaticalNumber.Plural,
            _ => throw new InvalidEnumArgumentException()
        };
        subjectNoun.Definiteness = request.SubjectDefiniteness switch
        {
            "definite" => Definiteness.Definite,
            "indefinite" => Definiteness.Indefinite,
            _ => throw new InvalidEnumArgumentException()
        };
        sentence.SubjectNoun = subjectNoun;
        sentence.Tense = request.Tense switch
        {
            "present" => Tense.Present,
            "perfect" => Tense.Perfect,
            "future" => Tense.Future,
            "past" => Tense.Past,
            _ => throw new InvalidEnumArgumentException()
        };
        sentence.Predicate = predicate;
        sentence.StatementOrQuestion = request.StatementOrQuestion switch
        {
            "statement" => StatementOrQuestion.Statement,
            "question" => StatementOrQuestion.Question,
            _ => throw new InvalidEnumArgumentException()
        };
        sentence.TenseBehavior = request.Tense switch
        {
            "present" => new PresentTense(),
            "perfect" => new PerfectTense(),
            "future" => new FutureTense(),
            "past" => new PastTense(),
            _ => throw new InvalidEnumArgumentException()
        };

        return sentence;
    }
}