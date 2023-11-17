using System.ComponentModel.DataAnnotations.Schema;

namespace Data.PersistenceEntities.Verbs.Shared
{
    [Table("Verbs")]
    public class BaseVerb 
    {
        public string Id { get; set; } = null!;
        public string Imperative { get; set; } = null!;
        public string PresentTense { get; set; } = null!;
        public string VerbConjugation { get; set; } = null!;
    }
}
