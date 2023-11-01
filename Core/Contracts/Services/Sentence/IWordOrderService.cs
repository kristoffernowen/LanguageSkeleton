namespace Domain.Contracts.Services.Sentence;

public interface IWordOrderService
{
    string ToQuestion(Models.Sentence.Sentence sentence);
    string ToStatement(Models.Sentence.Sentence sentence);
}