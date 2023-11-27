using System.ComponentModel;
using System.Text.RegularExpressions;
using Application.Contracts.Services.Noun;
using Domain.Enums;
using Domain.Models.Words;

namespace Application.Services.NounForms
{
    public class Definiteness : IDefiniteness
    {
        public Noun SetDisplayForm(Noun noun)
        {
            noun = noun.Definiteness switch
            {
                Domain.Enums.Definiteness.Indefinite => Indefinite(noun),
                Domain.Enums.Definiteness.Definite => Definite(noun),
                _ => throw new InvalidEnumArgumentException()
            };
            return noun;
        }
        public Noun Definite(Noun noun)
        {
            noun.Definiteness = Domain.Enums.Definiteness.Definite;
            noun.DisplayForm = noun.GrammaticalNumber switch
            {
                Domain.Enums.GrammaticalNumber.Singular => Singular(noun),
                Domain.Enums.GrammaticalNumber.Plural => Plural(noun),
                _ => throw new InvalidEnumArgumentException()
            };

            return noun;
        }

        public Noun Indefinite(Noun noun)
        {
            noun.Definiteness = Domain.Enums.Definiteness.Indefinite;
            noun.DisplayForm = noun.GrammaticalNumber switch
            {
                Domain.Enums.GrammaticalNumber.Singular => noun.SingularForm,
                Domain.Enums.GrammaticalNumber.Plural => noun.PluralForm,
                _ => throw new InvalidEnumArgumentException()
            };

            return noun;
        }

        private string Singular(Noun noun)
        {
            const string vowels = "[aeiouyåäö]$";
            var displayForm = noun.NounArticle switch
            {
                NounArticle.en when Regex.IsMatch(noun.SingularForm, vowels) => noun.SingularForm + "n",
                NounArticle.en when noun.SingularForm.EndsWith("el") => noun.SingularForm + "n",
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
