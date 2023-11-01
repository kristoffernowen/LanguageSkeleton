using Domain.Models.Words;

namespace Domain.Contracts.Repos;

public interface INounRepo
{
    public void CreateNoun(Noun noun);
    public Noun GetNoun(string id);
    public List<Noun> GetAllNouns();
}