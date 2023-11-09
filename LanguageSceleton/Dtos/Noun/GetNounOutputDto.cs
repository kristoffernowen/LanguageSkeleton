using System.Reflection.Metadata.Ecma335;

namespace LanguageSkeleton.Api.Dtos.Noun
{
    public class GetNounOutputDto
    {
        public string Id { get; set; } = null!;
        public string SingularForm { get; set; } = null!;

        public string DisplayForm { get; set; } = null!;
        public string GrammaticalNumber { get; set; } = null!;
        public string Definiteness { get; set; } = null!;
    }
}
