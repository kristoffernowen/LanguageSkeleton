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
                StatementOrQuestion.Statement => await Statement(sentence),
                StatementOrQuestion.Question => await Question(sentence),
                _ => throw new InvalidEnumArgumentException()
            };

            return sentence;
        }

        private async Task<string> Question(Sentence sentence)
        {
            sentence.SubjectElement = _arrangeClauseElementService.Subject(sentence);
            sentence.PredicateElement = await _arrangeClauseElementService.Predicate(sentence);

            return sentence.Tense switch
            {
                Tense.Present or Tense.Past =>
                    $"{sentence.Predicate.DisplayForm} {sentence.SubjectElement.DisplayForm}?",
                Tense.Perfect or Tense.Future =>
                    $"{sentence.PredicateElement.DictionaryOfWords["verb two"].DisplayForm}" +
                    $" {sentence.SubjectElement.DisplayForm} {sentence.PredicateElement.DictionaryOfWords["verb one"].DisplayForm}?",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        private async Task<string> Statement(Sentence sentence)
        {
            try
            {
                sentence.SubjectElement = _arrangeClauseElementService.Subject(sentence);
            }
            catch (Exception e)
            {
                Console.WriteLine("subject", e);
                throw;
            }
            try
            {
                sentence.PredicateElement = await _arrangeClauseElementService.Predicate(sentence);
            }
            catch (Exception e)
            {
                Console.WriteLine("predicate statement: ", e);
                throw;
            }

            return sentence.Tense switch
            {
                Tense.Present or Tense.Past => $"{sentence.SubjectElement.DisplayForm} " +
                                               $" {sentence.PredicateElement.DictionaryOfWords["verb one"].DisplayForm}.",
                Tense.Perfect or Tense.Future =>
                    $"{sentence.SubjectElement.DisplayForm} {sentence.PredicateElement.DictionaryOfWords["verb two"].DisplayForm}" +
                    $" {sentence.PredicateElement.DictionaryOfWords["verb one"].DisplayForm}.",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
