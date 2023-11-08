using Domain.Enums;

namespace Domain.Models.Words;

public class Verb : Word
{
    public string Infinitive => BaseForm;
    public string Imperative { get; set; } = null!;
    public string PresentTense { get; set; } = null!;
    public string? PastTense { get; set; } = null!;
    public string? Supine { get; set; } = null!;
    public VerbConjugation VerbConjugation { get; set; }
    public VowelChangeGroup VowelChangeGroup { get; set; }
}