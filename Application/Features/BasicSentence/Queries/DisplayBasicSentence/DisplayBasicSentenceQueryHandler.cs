using Application.Contracts.Repos;
using Application.Contracts.Services.Sentence;
using Application.Contracts.Services.Verb;
using Domain.Enums.Noun;
using MediatR;

namespace Application.Features.BasicSentence.Queries.DisplayBasicSentence
{
    public class DisplayBasicSentenceQueryHandler(
        ITenseManager tenseManager,
        IWordOrderService wordOrderService,
        IVerbRepo verbRepo,
        INounRepo nounRepo)
        : IRequestHandler<DisplayBasicSentenceQuery, DisplayBasicSentenceDto>
    {
        public async Task<DisplayBasicSentenceDto> Handle(DisplayBasicSentenceQuery request, CancellationToken cancellationToken)
        {
            var sentence = request.ToSentence(await nounRepo.GetNounAsync(request.SubjectId), await verbRepo.GetByIdAsync(request.PredicateId));
            sentence.SubjectForm = sentence.SubjectNoun.Inflect(
                request.SubjectGrammaticalNumber switch{"singular" => GrammaticalNumber.Singular, "plural" => GrammaticalNumber.Plural, _ => throw new Exception("switch mess") },
                request.SubjectDefiniteness switch{"indefinite" => Definiteness.Indefinite, "definite" => Definiteness.Definite, _ => throw new Exception("switch mess")},
                GrammaticalCase.Nominative);

            sentence.Predicate = tenseManager.SetDisplayForm(sentence.Tense, sentence.Predicate);
            sentence = await wordOrderService.ToQuestionOrStatementAsync(sentence);
            sentence.DisplaySentence = char.ToUpper(sentence.DisplaySentence[0]) +
                                       sentence.DisplaySentence[1..];

            return sentence.ToDto();
        }
    }
}
