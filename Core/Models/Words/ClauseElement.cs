namespace Domain.Models.Words
{
    public class ClauseElement
    {
        public string DisplayForm { get; set; } = null!;
        private Dictionary<string, Word> Words { get; set; } = new Dictionary<string, Word>();

        public Word this[string key]
        {
            get => Words[key];
            set => Words[key] = value;
        }
    }
}
