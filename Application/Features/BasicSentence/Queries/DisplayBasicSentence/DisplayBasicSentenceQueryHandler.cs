using Application.Contracts.Repos;
using Application.Contracts.Services.Noun;
using Application.Contracts.Services.Sentence;
using Application.Contracts.Services.Verb;
using MediatR;

namespace Application.Features.BasicSentence.Queries.DisplayBasicSentence
{
    public class DisplayBasicSentenceQueryHandler : IRequestHandler<DisplayBasicSentenceQuery, DisplayBasicSentenceDto>
    {
        private readonly INounManager _nounManager;
        private readonly ITenseManager _tenseManager;
        private readonly IWordOrderService _wordOrderService;
        private readonly IVerbRepo _verbRepo;
        private readonly INounRepo _nounRepo;


        public DisplayBasicSentenceQueryHandler(INounManager nounManager, ITenseManager tenseManager, IWordOrderService wordOrderService, IVerbRepo verbRepo, INounRepo nounRepo)
        {
            _nounManager = nounManager;
            _tenseManager = tenseManager;
            _wordOrderService = wordOrderService;
            _verbRepo = verbRepo;
            _nounRepo = nounRepo;
        }
        public async Task<DisplayBasicSentenceDto> Handle(DisplayBasicSentenceQuery request, CancellationToken cancellationToken)
        {
            var sentence = request.ToSentence(await _nounRepo.GetNounAsync(request.SubjectId), await _verbRepo.GetVerbAsync(request.PredicateId));

            sentence.SubjectNoun = _nounManager.SetDisplayForm(sentence.SubjectNoun);
            sentence.Predicate = _tenseManager.SetDisplayForm(sentence.Tense, sentence.Predicate);
            sentence = await _wordOrderService.ToQuestionOrStatementAsync(sentence);
            sentence.DisplaySentence = char.ToUpper(sentence.DisplaySentence[0]) +
                                       sentence.DisplaySentence[1..];

            return sentence.ToDto();
        }
    }
}
