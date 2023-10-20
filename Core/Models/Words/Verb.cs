using Core.Enums;

namespace Core.Models.Words;

public class Verb : Word
{
    public string Infinitive => BaseForm;
    public VerbConjugation VerbConjugation { get; set; }
}