using System.Reflection.Metadata.Ecma335;

namespace LanguageSceleton.Api.Dtos.Noun
{
    public class GetAllNounsOutputDto
    {
        public string BaseForm { get; set; } = null!;
        public string Id { get; set; } = null!;
    }
}
