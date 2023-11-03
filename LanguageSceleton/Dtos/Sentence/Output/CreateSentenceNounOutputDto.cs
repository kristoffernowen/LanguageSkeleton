namespace LanguageSkeleton.Api.Dtos.Sentence.Output
{
    public class CreateSentenceNounOutputDto
    {
        
            public string Id { get; set; } = null!;
            public string GrammaticalNumber { get; set; } = null!;
            public string Definiteness { get; set; } = null!;
            public string DisplayForm { get; set; } = null!;
    }
}
