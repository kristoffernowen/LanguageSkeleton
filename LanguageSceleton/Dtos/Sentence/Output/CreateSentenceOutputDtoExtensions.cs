using System.ComponentModel;
using Domain.Enums;

namespace LanguageSkeleton.Api.Dtos.Sentence.Output;

public static class CreateSentenceOutputDtoExtensions
{
    public static CreateSentenceOutputDto ToCreateOutputDto(this Domain.Models.Sentence.Sentence model
    )
    {
        return new CreateSentenceOutputDto()
        {
            SubjectNoun = model.SubjectNoun.ToSentenceNounOutputDto(),
            Predicate = model.Predicate.ToCreateSentenceVerbOutputDto(),
            
            Tense = model.Tense switch
            {
                Tense.Past => "past",
                Tense.Present => "present",
                _ => throw new InvalidEnumArgumentException()
            },
            StatementOrQuestion = model.StatementOrQuestion switch
            {
                StatementOrQuestion.Statement => "statement",
                StatementOrQuestion.Question => "question",
                _ => throw new InvalidEnumArgumentException()
            },
            DisplaySentence = model.DisplaySentence
        };
    }
}