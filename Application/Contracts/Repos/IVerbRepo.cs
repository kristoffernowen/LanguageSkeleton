using Domain.Models.Words;

namespace Application.Contracts.Repos;

public interface IVerbRepo
{
    public Task CreateAsync(Verb verb);
    public Task<Verb> GetByIdAsync(string id);
    public Task<Verb> GetFromPresentTenseAsync(string presentTense);
    public Task<List<Verb>> GetAsync();
}