namespace Application.Contracts.Services.Sentence
{
    public interface IQuestionOrStatementService
    {
        public Task<Domain.Models.Sentence.Sentence> ToQuestionOrStatementAsync(Domain.Models.Sentence.Sentence sentence);
    }
}
