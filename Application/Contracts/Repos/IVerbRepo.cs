using Domain.Enums;
using Domain.Models.Words;

namespace Application.Contracts.Repos;

public interface IVerbRepo
{
    public Task CreateVerbAsync(Verb verb);
    public Task<Verb> GetVerbAsync(string id);
    public Task<Verb> GetVerbFromPresentTenseAsync(string presentTense);
    // public Task<Verb> GetVerbAsync(string id, VerbConjugation verbConjugation);
    public Task<List<Verb>> GetAllVerbAsync();
}