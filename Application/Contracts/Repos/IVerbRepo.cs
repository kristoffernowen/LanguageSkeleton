using Domain.Models.Words;

namespace Application.Contracts.Repos;

public interface IVerbRepo
{
    public Task CreateVerbAsync(Verb verb);
    public Task<Verb> GetVerbAsync(string id);
    public Task<List<Verb>> GetAllVerbAsync();
}