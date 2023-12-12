using Domain.Enums;
using Domain.Models.Words;

namespace Domain.Models.Sentence
{
    public class Sentence
    {
        public Verb Predicate { get; set; } = null!;
        public Noun SubjectNoun { get; set; } = null!;
        public Noun? ObjectNoun { get; set; } = null!;
        public Tense Tense { get; set; }
        public StatementOrQuestion StatementOrQuestion { get; set; }
        public string DisplaySentence { get; set; } = "";
        public ClauseElement? SubjectElement { get; set; }
        public ClauseElement? PredicateElement { get; set; }
    }
}

// Rework. This will be main clause. Like this but maybe DisplayForm is a list<Word>.
// Add prop Clauses as List<Clause>. Could different Clause be of different classes
// that would be recognized and treated differently by service? Their words would be internally ordered 
// in the Clause.DisplayForm list and displayed through index. Then the clauses could be put in order and displayed 
// from index in DisplayForm.
// probably easier if mainclause is a separate class that is put inside sentence DisplayForm in the right index