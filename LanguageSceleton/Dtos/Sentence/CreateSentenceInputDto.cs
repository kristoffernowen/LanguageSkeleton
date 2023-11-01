namespace LanguageSkeleton.Api.Dtos.Sentence
{
    public class CreateSentenceInputDto
    {
        public Domain.Models.Words.Verb Predicate { get; set; } = null!;
        public Domain.Models.Words.Noun SubjectNoun { get; set; } = null!;
        public Domain.Models.Words.Noun ObjectNoun { get; set; } = null!;
        public string Tense { get; set; } = null!;
        public string StatementOrQuestion { get; set; } = null!;
        public string DisplaySentence { get; set; } = null!;
    }
}
