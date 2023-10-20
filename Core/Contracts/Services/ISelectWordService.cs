using Core.Models.Words;

namespace Core.Contracts.Services;

public interface ISelectWordService
{
    List<Verb> GetAllVerbs();
    List<Noun> GetAllNouns();
}