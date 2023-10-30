using Core.Enums;

namespace Data.PersistenceEntities;

public class VerbEntity
{
    public string Id { get; set; } = null!;
    public string BaseForm { get; set; } = null!;
    public VerbConjugation VerbConjugation { get; set; }
}