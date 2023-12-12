namespace Domain.Models.Words
{
    public class ClauseElement
    {
        public string DisplayForm { get; set; } = null!;
        private Dictionary<string, Word> Words { get; } = new();
        // List<Word> DisplayForm, method 1 arranges Words in correct order in DisplayForm
        // Then DisplayForm can be foreached or something

        public Word this[string key]
        {
            get => Words[key];
            set => Words[key] = value;
        }
    }
}
