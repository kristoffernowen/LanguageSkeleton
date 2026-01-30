using Domain.Enums.Noun;
using Domain.Models.Words;

namespace Domain.Models.ValueObjects;

public class NounForm(
    Noun lexem,
    string surfaceForm,
    GrammaticalNumber grammaticalNumber,
    Definiteness definiteness,
    GrammaticalCase grammaticalCase) : Word
{
    public Noun Lexem { get; } = lexem;
    public string SurfaceForm { get; } = surfaceForm;
    public GrammaticalNumber GrammaticalNumber { get; } = grammaticalNumber;
    public Definiteness Definiteness { get; } = definiteness;
    public GrammaticalCase GrammaticalCase { get; } = grammaticalCase;
}