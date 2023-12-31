﻿using System.ComponentModel;
using Domain.Enums;

namespace Application.Features.Nouns.Commands;

public static class CreateNounCommandExtensions
{
    public static Domain.Models.Words.Noun ToModel(this CreateNounCommand dto)
    {
        var noun = new Domain.Models.Words.Noun
        {
            SingularForm = dto.SingularForm,
            PluralForm = dto.PluralForm,
            NounArticle = dto.NounArticle switch
            {
                "en" => NounArticle.en,
                "ett" => NounArticle.ett,
                _ => throw new InvalidEnumArgumentException()
            },
            NounDeclension = dto.NounDeclension switch
            {
                1 => NounDeclension.One,
                2 => NounDeclension.Two,
                3 => NounDeclension.Three,
                4 => NounDeclension.Four,
                5 => NounDeclension.Five,
                _ => throw new InvalidEnumArgumentException()
            }
        };

        return noun;
    }
}