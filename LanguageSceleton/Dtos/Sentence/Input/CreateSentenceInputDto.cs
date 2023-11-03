namespace LanguageSkeleton.Api.Dtos.Sentence.Input
{
    public class CreateSentenceInputDto
    {
        public CreateSentenceVerbInputDto Predicate { get; set; } = null!;
        public CreateSentenceNounInputDto SubjectNounInput { get; set; } = null!;
        public CreateSentenceNounInputDto? ObjectNoun { get; set; } = null!;
        public string Tense { get; set; } = null!;
        public string StatementOrQuestion { get; set; } = null!;

    }
}
