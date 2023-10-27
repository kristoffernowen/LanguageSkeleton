using Core.Models.Words;

namespace Core.Contracts.Services.Noun;

public interface INounService
{
    public void CreateNoun(Models.Words.Noun noun);
    public List<Models.Words.Noun> GetAll();
}