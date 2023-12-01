using System.ComponentModel;
using Application.Services.NounForms;
using Domain.Enums;

namespace LanguageSkeleton.Api.Dtos.Noun;

public static class CreateNounInputDtoExtensions
{
    public static Domain.Models.Words.Noun ToModel(this CreateNounInputDto dto)
    {
        var noun = new Domain.Models.Words.Noun(new NounDisplayFormSetter())
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