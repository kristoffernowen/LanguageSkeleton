using Core.Models.Words;

namespace Core.Contracts.Services;

public interface INounService
{
    public void CreateNoun(Noun noun);
    public List<Noun> GetAll();
}