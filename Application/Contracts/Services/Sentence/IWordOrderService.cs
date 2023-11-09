namespace Application.Contracts.Services.Sentence
{
    public interface IWordOrderService
    {
        public Task<Domain.Models.Sentence.Sentence> ToQuestionOrStatementAsync(Domain.Models.Sentence.Sentence sentence);
    }
}
