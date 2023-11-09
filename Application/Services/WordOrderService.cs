using System.ComponentModel;
using Application.Contracts.Services.Noun;
using Application.Contracts.Services.Sentence;
using Domain.Enums;
using Domain.Models.Sentence;

namespace Application.Services
{
    public class WordOrderService : IWordOrderService
    {
        private readonly IArrangeClauseElementService _arrangeClauseElementService;

        public WordOrderService(IArrangeClauseElementService arrangeClauseElementService)
        {
            _arrangeClauseElementService = arrangeClauseElementService;
        }

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
            sentence.SubjectElement = _arrangeClauseElementService.Subject(sentence);

            return $"{sentence.Predicate.DisplayForm} {sentence.SubjectElement.DisplayForm}?";
        }
        private string Statement(Sentence sentence)
        {
            sentence.SubjectElement = _arrangeClauseElementService.Subject(sentence);

            return $"{sentence.SubjectElement.DisplayForm} {sentence.Predicate.DisplayForm}.";
        }
    }
}
