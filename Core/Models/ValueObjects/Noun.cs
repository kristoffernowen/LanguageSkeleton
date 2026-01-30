using Domain.Enums.Noun;
using Domain.Models.Words;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Domain.Models.ValueObjects;

public class Noun : Word
{
    public Noun(NounDeclension nounDeclension, NounArticle nounArticle, GrammaticalGender grammaticalGender, string singularForm, string pluralForm)
    {
        NounDeclension = nounDeclension;
        GrammaticalGender = grammaticalGender;
        SingularForm = singularForm;
        PluralForm = pluralForm;
        NounArticle = nounArticle;
    }

    public NounDeclension NounDeclension { get; set; }
    public NounArticle NounArticle { get; set; }
    public GrammaticalGender GrammaticalGender { get; set; }
    public string SingularForm { get; set; } = null!;
    public string PluralForm { get; set; } = null!;
    
    public NounForm Inflect(GrammaticalNumber grammaticalNumber,
        Definiteness definiteness,
        GrammaticalCase grammaticalCase)
    {
        var form = grammaticalNumber == GrammaticalNumber.Singular ? SingularForm
            : PluralForm;

        if (definiteness == Definiteness.Definite)
        {
            form = grammaticalNumber switch
            {
                GrammaticalNumber.Singular => SingularDefinite(form),
                GrammaticalNumber.Plural => PluralDefinite(form),
                _ => throw new InvalidEnumArgumentException()
            };
        }

        if (grammaticalCase == GrammaticalCase.Genitive && !form.EndsWith('s'))
        {
            form += "s";
        }
        return new NounForm(this, form, grammaticalNumber, definiteness, grammaticalCase);
    }

    private string SingularDefinite(string currentForm)
    {
        const string vowels = "[aeiouyåäö]$";
        var displayForm = NounArticle switch
        {
            NounArticle.en when Regex.IsMatch(currentForm, vowels) => currentForm + "n",
            NounArticle.en when currentForm.EndsWith("el") => currentForm + "n",
            NounArticle.en => currentForm + "en",
            NounArticle.ett when Regex.IsMatch(currentForm, vowels) => currentForm + "t",
            NounArticle.ett => currentForm + "et",
            _ => throw new ArgumentOutOfRangeException()
        };

        return displayForm;
    }

    private string PluralDefinite(string currentForm)
    {
        var displayForm = NounDeclension switch
        {
            NounDeclension.One => currentForm + "na",
            NounDeclension.Two => currentForm + "na",
            NounDeclension.Three => currentForm + "na",
            NounDeclension.Four => currentForm + "a",
            NounDeclension.Five => currentForm + "en",
            _ => throw new ArgumentOutOfRangeException()
        };

        return displayForm;
    }
}