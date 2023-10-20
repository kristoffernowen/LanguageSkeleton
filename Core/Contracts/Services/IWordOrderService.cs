using Core.Models.Sentence;

namespace Core.Contracts.Services;

public interface IWordOrderService
{
    string ToQuestion(Sentence sentence);
    string ToStatement(Sentence sentence);
}