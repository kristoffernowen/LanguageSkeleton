namespace Data.PersistenceEntities.Verbs.Shared
{
    public class BaseVerb : IVerb
    {
        public string Id { get; set; } = null!;
        public string Imperative { get; set; } = null!;
        public string PresentTense { get; set; } = null!;
        public string VerbConjugation { get; set; } = null!;
    }
}
