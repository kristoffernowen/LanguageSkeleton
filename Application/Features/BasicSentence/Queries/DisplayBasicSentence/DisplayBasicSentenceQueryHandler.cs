using System.ComponentModel;
using Application.Contracts.Services.Noun;
using Application.Contracts.Services.Sentence;
using Application.Contracts.Services.Verb;
using MediatR;

namespace Application.Features.BasicSentence.Queries.DisplayBasicSentence
{
    public class DisplayBasicSentenceQueryHandler : IRequestHandler<DisplayBasicSentenceQuery, DisplayBasicSentenceDto>
    {
        private readonly INounManager _nounManager;
        private readonly IVerbService _verbService;
        private readonly IWordOrderService _wordOrderService;
        private readonly IPastTenseService _pastTenseService;
        private readonly IPresentTenseService _presentTenseService;
        private readonly IPerfectTenseService _perfectTenseService;
        private readonly IFutureTenseService _futureTenseService;

        public DisplayBasicSentenceQueryHandler(INounManager nounManager, IVerbService verbService, IWordOrderService wordOrderService,
            IPastTenseService pastTenseService, IPresentTenseService presentTenseService, IPerfectTenseService perfectTenseService,
            IFutureTenseService futureTenseService)
        {
            _nounManager = nounManager;
            _verbService = verbService;
            _wordOrderService = wordOrderService;
            _pastTenseService = pastTenseService;
            _presentTenseService = presentTenseService;
            _perfectTenseService = perfectTenseService;
            _futureTenseService = futureTenseService;
        }
        public async Task<DisplayBasicSentenceDto> Handle(DisplayBasicSentenceQuery request, CancellationToken cancellationToken)
        {
            var sentence = request.ToSentence(await _nounManager.NounService.GetAsync(request.SubjectId), await _verbService.GetAsync(request.PredicateId));

            sentence.SubjectNoun = _nounManager.NounService.GrammaticalNumberDisplayForm(sentence.SubjectNoun);
            sentence.SubjectNoun = _nounManager.DefinitenessService.SetDefinitenessDisplayForm(sentence.SubjectNoun);
            sentence.Predicate = request.Tense switch
            {
                "present" => _presentTenseService.SetDisplayForm(sentence.Predicate),
                "past" => _pastTenseService.SetDisplayForm(sentence.Predicate),
                "perfect" => _perfectTenseService.SetDisplayForm(sentence.Predicate),
                "future" => _futureTenseService.SetDisplayForm(sentence.Predicate),
                _ => throw new InvalidEnumArgumentException()
            };
            sentence = await _wordOrderService.ToQuestionOrStatementAsync(sentence);
            sentence.DisplaySentence = char.ToUpper(sentence.DisplaySentence[0]) +
                                       sentence.DisplaySentence[1..];

            return sentence.ToDto();
        }
    }
}
