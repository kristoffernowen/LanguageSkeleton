using Core.Models.Words;

namespace Core.Contracts.Services.Sentence;

public interface ISelectWordService
{
    List<Models.Words.Verb> GetAllVerbs();
    List<Models.Words.Noun> GetAllNouns();
}