using Domain.Enums;

namespace Domain.Models.Words;

public class Noun : Word
{

    public NounDeclension NounDeclension { get; set; }
    public NounArticle NounArticle { get; set; }
    public string SingularForm { get; set; } = null!;
    public string PluralForm { get; set; } = null!;
    public GrammaticalNumber? GrammaticalNumber { get; set; }
    public Definiteness? Definiteness { get; set; }
}