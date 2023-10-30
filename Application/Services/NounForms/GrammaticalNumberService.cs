﻿using Core.Contracts.Services.Noun;
using Core.Enums;
using Core.Models.Words;

namespace Application.Services.NounForms
{
    public class GrammaticalNumberService : IGrammaticalNumberService
    {
        public Noun Singular(Noun noun)
        {
            noun.GrammaticalNumber = GrammaticalNumber.Singular;
            noun.DisplayForm = noun.SingularForm;

            return noun;
        }

        public Noun Plural(Noun noun)
        {
            noun.GrammaticalNumber = GrammaticalNumber.Plural;
            noun.DisplayForm = noun.PluralForm;

            return noun;
        }
    }
}
