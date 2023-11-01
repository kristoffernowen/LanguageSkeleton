using System.ComponentModel;
using System.Text.RegularExpressions;
using Domain.Contracts.Services.Noun;
using Domain.Enums;
using Domain.Models.Words;

namespace Application.Services.NounForms
{
    public class DefinitenessService : IDefinitenessService
    {
        public Noun Definite(Noun noun)
        {
            noun.Definiteness = Definiteness.Definite;
            noun.DisplayForm = noun.GrammaticalNumber switch
            {
                GrammaticalNumber.Singular => Singular(noun),
                GrammaticalNumber.Plural => Plural(noun),
                _ => throw new InvalidEnumArgumentException()
            };

            return noun;
        }

        public Noun Indefinite(Noun noun)
        {
            noun.Definiteness = Definiteness.Indefinite;
            noun.DisplayForm = noun.GrammaticalNumber switch
            {
                GrammaticalNumber.Singular => noun.SingularForm,
                GrammaticalNumber.Plural => noun.PluralForm,
                _ => throw new InvalidEnumArgumentException()
            };

            return noun;
        }

        private string Singular(Noun noun)
        {
            var displayForm = "";
            const string vowels = "[aeiouyåäö]$";
            displayForm = noun.NounArticle switch
            {
                NounArticle.en when Regex.IsMatch(noun.SingularForm, vowels) => noun.SingularForm + "n",
                NounArticle.en => noun.SingularForm + "en",
                NounArticle.ett when Regex.IsMatch(noun.SingularForm, vowels) => noun.SingularForm + "t",
                NounArticle.ett => noun.SingularForm + "et",
                _ => throw new ArgumentOutOfRangeException()
            };

            return displayForm;
        }

        private string Plural(Noun noun)
        {
            var displayForm = noun.NounDeclension switch
            {
                NounDeclension.One => noun.PluralForm + "na",
                NounDeclension.Two => noun.PluralForm + "na",
                NounDeclension.Three => noun.PluralForm + "na",
                NounDeclension.Four => noun.PluralForm + "a",
                NounDeclension.Five => noun.PluralForm + "en",
                _ => throw new ArgumentOutOfRangeException()
            };

            return displayForm;
        }
    }
}
