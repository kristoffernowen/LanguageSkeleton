using Domain.Models.Words;

namespace Application.Contracts.Repos;

public interface INounRepo
{
    public Task CreateNounAsync(Noun noun);
    public Task<Noun> GetNounAsync(string id);
    public Task<List<Noun>> GetAllNounsAsync();
}