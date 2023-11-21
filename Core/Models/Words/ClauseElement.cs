namespace Domain.Models.Words
{
    public class ClauseElement
    {
        public string DisplayForm { get; set; } = null!;
        private Dictionary<string, Word> Words { get; } = new();

        public Word this[string key]
        {
            get => Words[key];
            set => Words[key] = value;
        }
    }
}
