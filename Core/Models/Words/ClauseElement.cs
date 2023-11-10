namespace Domain.Models.Words
{
    public class ClauseElement
    {
        public string DisplayForm { get; set; } = null!;
        
        public Dictionary<string, Word> DictionaryOfWords { get; set; } = new Dictionary<string, Word>();
    }
}
