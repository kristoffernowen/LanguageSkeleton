namespace Domain.Contracts.Services.Noun;

public interface INounService
{
    public void CreateNoun(Models.Words.Noun noun);
    public List<Models.Words.Noun> GetAll();
    public Models.Words.Noun Get(string id);
}