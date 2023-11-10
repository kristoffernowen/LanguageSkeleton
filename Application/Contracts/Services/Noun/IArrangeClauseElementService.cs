using Domain.Models.Words;

namespace Application.Contracts.Services.Noun
{
    public interface IArrangeClauseElementService
    {
        ClauseElement Subject(Domain.Models.Sentence.Sentence sentence);
        Task<ClauseElement> Predicate(Domain.Models.Sentence.Sentence sentence);
    }
}
