using System.ComponentModel;
using Domain.Enums;

namespace LanguageSkeleton.Api.Dtos.Sentence.Input
{
    public class CreateSentenceVerbInputDto
    {

        public string Id { get; set; } = null!;
        public string BaseForm { get; set; } = null!;

        public string VerbConjugation { get; set; } = null!;
    }

    public static class CreateSentenceVerbDtoExtensions
    {
        public static Domain.Models.Words.Verb ToModel(this CreateSentenceVerbInputDto inputDto)
        {
            return new Domain.Models.Words.Verb()
            {
                Id = inputDto.Id,
                BaseForm = inputDto.BaseForm,
                VerbConjugation = inputDto.VerbConjugation switch
                {
                    "ArVerb" => VerbConjugation.ArVerb,
                    "ErVerb" => VerbConjugation.ErVerb,
                    "RVerb" => VerbConjugation.RVerb,
                    "StrongErVerb" => VerbConjugation.StrongErVerb,
                    _ => throw new InvalidEnumArgumentException()
                }
            };
        }
    }
}
