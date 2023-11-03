namespace Application.Contracts.Services.Verb;

public interface IPastTenseService
{
    public Domain.Models.Words.Verb PastTense(Domain.Models.Words.Verb verb);
}