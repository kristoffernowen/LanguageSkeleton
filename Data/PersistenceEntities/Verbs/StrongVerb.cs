using Data.PersistenceEntities.Verbs.Shared;
using Domain.Enums;

namespace Data.PersistenceEntities.Verbs;

public class StrongVerb : BaseVerb
{
    public VowelChangeGroup VowelChangeGroup { get; set; }
}