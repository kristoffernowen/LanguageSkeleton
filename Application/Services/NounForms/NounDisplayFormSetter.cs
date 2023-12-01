using Domain.Enums;
using Domain.Models.Words;
using System.Text.RegularExpressions;

namespace Application.Services.NounForms
{
    public class NounDisplayFormSetter : INounDisplayFormSetter
    {
        public string SetForm(string baseForm, NounDeclension declension, Domain.Enums.Definiteness? definiteness,
            Domain.Enums.GrammaticalNumber? number, NounArticle article)
        {
            if (number == Domain.Enums.GrammaticalNumber.Singular && definiteness == Domain.Enums.Definiteness.Definite)
            {
                const string vowels = "[aeiouyåäö]$";
                var displayForm = article switch
                {
                    NounArticle.en when Regex.IsMatch(baseForm, vowels) => baseForm + "n",
                    NounArticle.en when baseForm.EndsWith("el") => baseForm + "n",
                    NounArticle.en => baseForm + "en",
                    NounArticle.ett when Regex.IsMatch(baseForm, vowels) => baseForm + "t",
                    NounArticle.ett => baseForm + "et",
                    _ => throw new ArgumentOutOfRangeException()
                };

                return displayForm;
            }

            else
            {
                throw new NotImplementedException("investigating behavior for noun display form on domain model. Unexpected to see this");
            }
        }
    }
}
