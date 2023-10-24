using Core.Models.Words;

namespace Core.Contracts.Services;

public interface IPastTenseService
{
    public Verb PastTense(Verb verb);
}