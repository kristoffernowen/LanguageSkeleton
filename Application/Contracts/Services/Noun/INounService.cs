namespace Application.Contracts.Services.Noun;

public interface INounService
{
    public Task CreateNounAsync(Domain.Models.Words.Noun noun);
    public Task<List<Domain.Models.Words.Noun>> GetAllAsync();
    public Task<Domain.Models.Words.Noun> GetAsync(string id);
    public Domain.Models.Words.Noun GrammaticalNumberDisplayForm(Domain.Models.Words.Noun noun);
}