using Core.Enums;

namespace LanguageSceleton.Api.Dtos.Verb
{
    public class CreateVerbInputDto
    {
        public string BaseForm { get; set; } = null!;
        public string VerbConjugation { get; set; } = null!;
    }
}
