namespace LanguageSkeleton.Api.Dtos.Sentence.Output;

public class CreateSentenceOutputDto
{
    public CreateSentenceVerbOutputDto Predicate { get; set; } = null!;
    public CreateSentenceNounOutputDto SubjectNoun { get; set; } = null!;
    public CreateSentenceNounOutputDto? ObjectNoun { get; set; }
    public string Tense { get; set; } = null!;
    public string StatementOrQuestion { get; set; } = null!;
    public string DisplaySentence { get; set; } = null!;
}