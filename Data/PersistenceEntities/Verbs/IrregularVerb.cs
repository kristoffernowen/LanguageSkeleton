using Data.PersistenceEntities.Verbs.Shared;

namespace Data.PersistenceEntities.Verbs;

public class IrregularVerb : BaseVerb
{
    public string Infinitive { get; set; } = null!;
    public string PastTense { get; set; } = null!;
    public string Supine { get; set; } = null!;


}