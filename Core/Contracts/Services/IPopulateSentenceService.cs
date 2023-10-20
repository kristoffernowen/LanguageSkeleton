using Core.Models.Sentence;

namespace Core.Contracts.Services;

public interface IPopulateSentenceService
{
    Sentence CreateSentence(Sentence sentence);
    Sentence AddObjectToSentence(Sentence sentence);
    Sentence RemoveObjectFromSentence(Sentence sentence);
}