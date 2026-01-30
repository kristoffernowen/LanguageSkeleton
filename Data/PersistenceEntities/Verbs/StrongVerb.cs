using Data.PersistenceEntities.Verbs.Shared;
using Domain.Enums.Verb;

namespace Data.PersistenceEntities.Verbs;

public class StrongVerb : BaseVerb
{
    public VowelChangeGroup VowelChangeGroup { get; set; }
}