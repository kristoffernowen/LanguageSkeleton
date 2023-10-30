namespace LanguageSceleton.Api.Dtos.Noun
{
    public class CreateNounInputDto
    {
        public string BaseForm { get; set; } = null!;
        public string PluralForm { get; set; } = null!;
        public int NounDeclension { get; set; }
        public string NounArticle { get; set; } = null!;
    }
}
