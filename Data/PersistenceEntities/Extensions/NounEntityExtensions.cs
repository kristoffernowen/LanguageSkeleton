using Application.Services.NounForms;
using Domain.Models.Words;

namespace Data.PersistenceEntities.Extensions
{
    public static class NounEntityExtensions
    {
        public static Noun ToModel(this NounEntity entity)
        {
            return new Noun(new NounDisplayFormSetter())
            {
                DisplayForm = "",
                Id = entity.Id,
                SingularForm = entity.SingularForm,
                PluralForm = entity.PluralForm,
                NounArticle = entity.NounArticle,
                NounDeclension = entity.NounDeclension
            };
        }
    }
}
