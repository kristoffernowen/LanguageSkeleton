namespace Blazor.UI.Models.BasicSentence
{
    public class DisplayBasicSentenceVm
    {
        public string Tense { get; set; } = null!;
        public string? DisplaySentence { get; set; } = null!;
        public string StatementOrQuestion { get; set; } = null!;
        public string PredicateId { get; set; } = null!;
        public string PredicatePresentTense { get; set; } = null!;
        public string PredicateVerbConjugation { get; set; } = null!;

        public string SubjectId { get; set; } = null!;
        public string SubjectDefiniteness { get; set; } = null!;
        public string SubjectGrammaticalNumber { get; set; } = null!;

        public string? ObjectId { get; set; }
        public string? ObjectGrammaticalNumber { get; set; }
        public string? ObjectDefiniteness { get; set; }

    }
}
