using Domain.Enums;

namespace Data.PersistenceEntities
{
    public class NounEntity
    {
        public string Id { get; set; } = null!;
        public string BaseForm { get; set; } = null!;
        public NounDeclension NounDeclension { get; set; }
        public NounArticle NounArticle { get; set; }
        public string PluralForm { get; set; } = null!;
    }
}
