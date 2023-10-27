using Core.Models.Words;

namespace Core.Contracts.Services.Verb;

public interface IPastTenseService
{
    public Models.Words.Verb PastTense(Models.Words.Verb verb);
}