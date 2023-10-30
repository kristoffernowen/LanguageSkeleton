using Core.Enums;
using Core.Models.Words;

namespace Core.Models.Sentence
{
    public class Sentence
    {
        public Verb Predicate { get; set; } = null!;
        public Noun SubjectNoun { get; set; } = null!;
        public Noun ObjectNoun { get; set; } = null!;
        public Tense Tense { get; set; }
        public StatementOrQuestion StatementOrQuestion { get; set; }
    }
}
