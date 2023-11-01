using Domain.Models.Words;

namespace Domain.Contracts.Repos;

public interface IVerbRepo
{
    public void CreateVerb(Verb verb);
    public Verb GetVerb(string id);
    public List<Verb> GetAllVerb();
}