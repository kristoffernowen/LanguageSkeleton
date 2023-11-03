using System.ComponentModel;
using Domain.Enums;

namespace Application.Dtos.Sentence.Input;

public static class CreateSentenceInputDtoExtensions
{
    public static Domain.Models.Sentence.Sentence ToModel(this CreateSentenceInputDto dto)
    {
        return new Domain.Models.Sentence.Sentence()
        {
            SubjectNoun = dto.SubjectNounInput.ToModel(),
            Predicate = dto.Predicate.ToModel(),
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
            }
        };
    }
}