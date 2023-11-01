namespace Domain.Contracts.Services.Sentence;

public interface IPopulateSentenceService
{
    Models.Sentence.Sentence CreateSentence(Models.Sentence.Sentence sentence);
    Models.Sentence.Sentence AddObjectToSentence(Models.Sentence.Sentence sentence);
    Models.Sentence.Sentence RemoveObjectFromSentence(Models.Sentence.Sentence sentence);
}