using Application.Contracts.Services.Noun;
using Domain.Enums;
using Domain.Models.Words;
using System.ComponentModel;

namespace Application.Services.NounForms
{
    public class GrammaticalNumberService : IGrammaticalNumberService
    {
        // public Noun Singular(Noun noun)
        // {
        //     noun.GrammaticalNumber = GrammaticalNumber.Singular;
        //     noun.DisplayForm = noun.SingularForm;
        //
        //     return noun;
        // }
        //
        // public Noun Plural(Noun noun)
        // {
        //     noun.GrammaticalNumber = GrammaticalNumber.Plural;
        //     noun.DisplayForm = noun.PluralForm;
        //
        //     return noun;
        // }

        public Noun GrammaticalNumberDisplayForm(Noun noun)
        {
            noun.DisplayForm = noun.GrammaticalNumber switch
            {
                Domain.Enums.GrammaticalNumber.Singular => noun.SingularForm,
                Domain.Enums.GrammaticalNumber.Plural => noun.PluralForm,
                _ => throw new InvalidEnumArgumentException()
            };

            return noun;
        }
    }
}
