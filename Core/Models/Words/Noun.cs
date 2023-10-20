using Core.Enums;

namespace Core.Models.Words;

public class Noun : Word
{
    
    public NounDeclension NounDeclension { get; set; }
    public NounArticle NounArticle { get; set; }
}