using System.ComponentModel;
using Domain.Enums.Noun;
using Domain.Models.ValueObjects;

namespace Application.Features.Nouns.Commands;

public static class CreateNounCommandExtensions
{
    public static Noun ToModel(this CreateNounCommand dto)
    {
        var noun = new Noun
        {
            SingularForm = dto.SingularForm,
            PluralForm = dto.PluralForm,
            GrammaticalGender = dto.GrammaticalGender switch
            {
                "masculine" => GrammaticalGender.Masculine,
                "feminine" => GrammaticalGender.Feminine,
                "neuter" => GrammaticalGender.Neuter,
                "common" => GrammaticalGender.CommonGender,
                _ => throw new InvalidEnumArgumentException()
            },
            NounArticle = dto.NounArticle switch
            {
                "definite" => NounArticle.en,
                "indefinite" => NounArticle.ett,
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