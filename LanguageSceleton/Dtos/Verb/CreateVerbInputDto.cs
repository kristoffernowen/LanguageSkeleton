

namespace LanguageSkeleton.Api.Dtos.Verb
{
    public class CreateVerbInputDto
    {
        public string Infinitive { get; set; } = null!;
        public string Imperative { get; set; } = null!;
        public string PresentTense { get; set; } = null!;
        public string PastTense { get; set; } = null!;
        public string Supine { get; set; } = null!;
        public string VerbConjugation { get; set; } = null!;
    }
}
