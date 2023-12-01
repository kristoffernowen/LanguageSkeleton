namespace Application.Features.Nouns.Queries.GetNoun;

public class GetNounQueryDto
{
    public string Id { get; set; } = null!;
    public string SingularForm { get; set; } = null!;

    public string DisplayForm { get; set; } = null!;
    public string GrammaticalNumber { get; set; } = null!;
    public string Definiteness { get; set; } = null!;
}