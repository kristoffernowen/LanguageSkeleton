using System.ComponentModel;
using Application.Contracts.Services.Sentence;
using Domain.Enums;
using Domain.Models.Sentence;

namespace Application.Services
{
    public class WordOrderService : IWordOrderService
    {
        public async Task<Sentence> ToQuestionOrStatementAsync(Sentence sentence)
        {
            sentence.DisplaySentence = sentence.StatementOrQuestion switch
            {
                StatementOrQuestion.Statement => Statement(sentence),
                StatementOrQuestion.Question => Question(sentence),
                _ => throw new InvalidEnumArgumentException()
            };

            return sentence;
        }

        private string Question(Sentence sentence)
        {
            return $"{sentence.Predicate.DisplayForm} {sentence.SubjectNoun.DisplayForm}?";
        }
        private string Statement(Sentence sentence)
        {
            return $"{sentence.SubjectNoun.DisplayForm} {sentence.Predicate.DisplayForm}.";
        }
    }
}
