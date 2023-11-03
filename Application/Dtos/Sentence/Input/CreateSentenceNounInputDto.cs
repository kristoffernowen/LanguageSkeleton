namespace Application.Dtos.Sentence.Input;

public class CreateSentenceNounInputDto
{
    public string Id { get; set; } = null!;
    public string GrammaticalNumber { get; set; } = null!;
    public string Definiteness { get; set; } = null!;
}