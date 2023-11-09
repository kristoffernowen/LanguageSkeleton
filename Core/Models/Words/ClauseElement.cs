namespace Domain.Models.Words
{
    public class ClauseElement
    {
        public List<Word> Words { get; set; } = new List<Word>();
        public string DisplayForm { get; set; } = null!;
        public string? Article { get; set; }
        public string? Noun { get; set; }
        public string? Adjective { get; set; }
        public string? Pronoun { get; set; }
    }
}
