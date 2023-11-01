using System.ComponentModel;
using Domain.Enums;

namespace LanguageSkeleton.Api.Dtos.Sentence;

public static class CreateSentenceInputDtoExtensions
{
    public static Domain.Models.Sentence.Sentence ToModel(this CreateSentenceInputDto dto)
    {
        return new Domain.Models.Sentence.Sentence()
        {
            SubjectNoun = dto.SubjectNoun,
            Predicate = dto.Predicate,
            ObjectNoun = dto.ObjectNoun,
            Tense = dto.Tense switch
            {
                "past" => Tense.Past,
                "present" => Tense.Present,
                _ => throw new InvalidEnumArgumentException()
            },
            StatementOrQuestion = dto.StatementOrQuestion switch
            {
                "statement" => StatementOrQuestion.Statement,
                "question" => StatementOrQuestion.Question,
                _ => throw new InvalidEnumArgumentException()
            },
            DisplaySentence = dto.DisplaySentence
        };
    }
}