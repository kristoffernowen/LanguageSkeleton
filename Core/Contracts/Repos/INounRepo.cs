using Core.Models.Words;

namespace Core.Contracts.Repos;

public interface INounRepo
{
    public void CreateNoun(Noun noun);
    public Noun GetNoun(string id);
    public List<Noun> GetAllNouns();
}