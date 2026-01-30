using System.ComponentModel;
using Domain.Enums.Verb;

namespace Application.Dtos.Sentence.Input
{
    public class CreateSentenceVerbInputDto
    {

        public string Id { get; set; } = null!;
        public string PresentTense { get; set; } = null!;

        public string VerbConjugation { get; set; } = null!;
    }

    public static class CreateSentenceVerbDtoExtensions
    {
        public static Domain.Models.Words.Verb ToModel(this CreateSentenceVerbInputDto inputDto)
        {
            return new Domain.Models.Words.Verb()
            {
                Id = inputDto.Id,
                PresentTense = inputDto.PresentTense,
                VerbConjugation = inputDto.VerbConjugation switch
                {
                    "ArVerb" => VerbConjugation.WeakOne,
                    "ErVerb" => VerbConjugation.WeakTwo,
                    "RVerb" => VerbConjugation.WeakThree,
                    "StrongErVerb" => VerbConjugation.StrongFour,
                    _ => throw new InvalidEnumArgumentException()
                }
            };
        }
    }
}
