using Domain.Enums;
using Domain.Models.Words;

namespace Domain.Models.Sentence
{
    public class Sentence
    {
        public Verb Predicate { get; set; } = null!;
        public Noun SubjectNoun { get; set; } = null!;
        public Noun ObjectNoun { get; set; } = null!;
        public Tense Tense { get; set; }
        public StatementOrQuestion StatementOrQuestion { get; set; }
        public string DisplaySentence { get; set; } = null!;
    }
}
