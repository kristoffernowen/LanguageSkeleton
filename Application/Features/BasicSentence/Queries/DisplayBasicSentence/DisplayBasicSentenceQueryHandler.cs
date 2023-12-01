using Application.Contracts.Services.Noun;
using Application.Contracts.Services.Sentence;
using Application.Contracts.Services.Verb;
using MediatR;

namespace Application.Features.BasicSentence.Queries.DisplayBasicSentence
{
    public class DisplayBasicSentenceQueryHandler : IRequestHandler<DisplayBasicSentenceQuery, DisplayBasicSentenceDto>
    {
        private readonly INounManager _nounManager;
        private readonly IWordOrderService _wordOrderService;
        private readonly IVerbService _verbService;
        private readonly INounService _nounService;


        public DisplayBasicSentenceQueryHandler(INounManager nounManager, IWordOrderService wordOrderService, IVerbService verbService, INounService nounService)
        {
            _nounManager = nounManager;
            _wordOrderService = wordOrderService;
            _verbService = verbService;
            _nounService = nounService;
        }
        public async Task<DisplayBasicSentenceDto> Handle(DisplayBasicSentenceQuery request, CancellationToken cancellationToken)
        {
            var sentence = request.ToSentence(await _nounService.GetAsync(request.SubjectId), await _verbService.GetAsync(request.PredicateId));

            // sentence.SubjectNoun = _nounManager.SetDisplayForm(sentence.SubjectNoun);
            sentence.SubjectNoun.SetDisplayForm();
            sentence.Predicate = sentence.TenseBehavior.SetDisplayForm(sentence.Predicate);

            

            sentence = await _wordOrderService.ToQuestionOrStatementAsync(sentence);
            sentence.DisplaySentence = char.ToUpper(sentence.DisplaySentence[0]) +
                                       sentence.DisplaySentence[1..];
            
            return sentence.ToDto();
        }
    }
}
