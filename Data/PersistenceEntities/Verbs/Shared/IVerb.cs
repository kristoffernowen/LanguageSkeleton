namespace Data.PersistenceEntities.Verbs.Shared
{
    public interface IVerb
    {
        public string Id { get; set; }
        public string Imperative { get; set; }
        public string PresentTense { get; set; }
        public string VerbConjugation { get; set; }
    }
}
