using Domain.Enums.Verb;

namespace Data.PersistenceEntities;

public class VerbEntity
{
    public string Id { get; set; } = null!;
    public string Infinitive { get; set; } = null!;
    public string Imperative { get; set; } = null!;
    public string PresentTense { get; set; } = null!;
    public string PastTense { get; set; } = null!;
    public string Supine { get; set; } = null!;
    public VerbConjugation VerbConjugation { get; set; }
}