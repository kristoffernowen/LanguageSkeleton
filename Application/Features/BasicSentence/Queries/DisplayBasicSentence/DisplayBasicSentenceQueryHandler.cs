using System.ComponentModel;
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
        private readonly IVerbService _verbService;
        private readonly INounService _nounService;


        public DisplayBasicSentenceQueryHandler(INounManager nounManager, ITenseManager tenseManager, IWordOrderService wordOrderService, IVerbService verbService, INounService nounService)
        {
            _nounManager = nounManager;
            _tenseManager = tenseManager;
            _wordOrderService = wordOrderService;
            _verbService = verbService;
            _nounService = nounService;
        }
        public async Task<DisplayBasicSentenceDto> Handle(DisplayBasicSentenceQuery request, CancellationToken cancellationToken)
        {
            var sentence = request.ToSentence(await _nounService.GetAsync(request.SubjectId), await _verbService.GetAsync(request.PredicateId));

            sentence.SubjectNoun = _nounManager.GrammaticalNumber.GrammaticalNumberDisplayForm(sentence.SubjectNoun);
            sentence.SubjectNoun = _nounManager.DefinitenessService.SetDefinitenessDisplayForm(sentence.SubjectNoun);
            sentence.Predicate = request.Tense switch
            {
                "present" => _tenseManager.PresentTenseService.SetDisplayForm(sentence.Predicate),
                "past" => _tenseManager.PastTenseService.SetDisplayForm(sentence.Predicate),
                "perfect" => _tenseManager.PerfectTenseService.SetDisplayForm(sentence.Predicate),
                "future" => _tenseManager.FutureTenseService.SetDisplayForm(sentence.Predicate),
                _ => throw new InvalidEnumArgumentException()
            };
            sentence = await _wordOrderService.ToQuestionOrStatementAsync(sentence);
            sentence.DisplaySentence = char.ToUpper(sentence.DisplaySentence[0]) +
                                       sentence.DisplaySentence[1..];

            return sentence.ToDto();
        }
    }
}
