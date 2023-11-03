namespace Application.Dtos.Sentence.Output
{
    public class CreateSentenceVerbOutputDto
    {
        

            public string Id { get; set; } = null!;
            public string BaseForm { get; set; } = null!;
            public string DisplayForm { get; set; } = null!;

            public string VerbConjugation { get; set; } = null!;
        }
}
