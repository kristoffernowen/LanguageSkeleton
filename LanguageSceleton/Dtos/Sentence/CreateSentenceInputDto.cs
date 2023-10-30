namespace LanguageSceleton.Api.Dtos.Sentence
{
    public class CreateSentenceInputDto
    {
        public Core.Models.Words.Verb Predicate { get; set; } = null!;
        public Core.Models.Words.Noun SubjectNoun { get; set; } = null!;
        public Core.Models.Words.Noun ObjectNoun { get; set; } = null!;
        public string Tense { get; set; } = null!;
        public string StatementOrQuestion { get; set; } = null!;
        public string DisplaySentence { get; set; } = null!;
    }
}
