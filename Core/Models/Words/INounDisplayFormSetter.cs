using Domain.Enums;

namespace Domain.Models.Words
{
    public interface INounDisplayFormSetter
    {
        string SetForm(string baseForm, NounDeclension declension, Definiteness? definiteness, GrammaticalNumber? number, NounArticle article);
    }
}
