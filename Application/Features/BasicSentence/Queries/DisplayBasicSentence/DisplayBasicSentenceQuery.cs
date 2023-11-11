using MediatR;

namespace Application.Features.BasicSentence.Queries.DisplayBasicSentence
{
    public class DisplayBasicSentenceQuery : IRequest<DisplayBasicSentenceDto>
    {
        public string Tense { get; set; } = null!;
        public string StatementOrQuestion { get; set; } = null!;

        public string SubjectId { get; set; } = null!;
        public string SubjectGrammaticalNumber { get; set; } = null!;
        public string SubjectDefiniteness { get; set; } = null!;
        public string PredicateId { get; set; } = null!;
        public string PredicatePresentTense { get; set; } = null!;

        public string PredicateVerbConjugation { get; set; } = null!;
        public string? ObjectId { get; set; } = null!;
        public string? ObjectGrammaticalNumber { get; set; } = null!;
        public string? ObjectDefiniteness { get; set; } = null!;
    }
}
