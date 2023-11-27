using Application.Contracts.Services.Noun;
using Domain.Enums;
using Domain.Models.Words;
using System.ComponentModel;

namespace Application.Services.NounForms
{
    public class GrammaticalNumber : IGrammaticalNumber
    {
        public Noun SetDisplayForm(Noun noun)
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
