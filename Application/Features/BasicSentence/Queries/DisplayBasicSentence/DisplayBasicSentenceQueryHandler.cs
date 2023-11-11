using System.ComponentModel;
using Application.Contracts.Services.Noun;
using Application.Contracts.Services.Sentence;
using Application.Contracts.Services.Verb;
using Domain.Enums;
using Domain.Models.Sentence;
using MediatR;

namespace Application.Features.BasicSentence.Queries.DisplayBasicSentence
{
    public class DisplayBasicSentenceQueryHandler : IRequestHandler<DisplayBasicSentenceQuery, DisplayBasicSentenceDto>
    {
        private readonly IDefinitenessService _definitenessService;
        private readonly INounService _nounService;
        private readonly IVerbService _verbService;
        private readonly IWordOrderService _wordOrderService;
        private readonly IPastTenseService _pastTenseService;
        private readonly IPresentTenseService _presentTenseService;
        private readonly IPerfectTenseService _perfectTenseService;
        private readonly IFutureTenseService _futureTenseService;

        public DisplayBasicSentenceQueryHandler(IDefinitenessService definitenessService,
            INounService nounService, IVerbService verbService, IWordOrderService wordOrderService,
            IPastTenseService pastTenseService, IPresentTenseService presentTenseService, IPerfectTenseService perfectTenseService,
            IFutureTenseService futureTenseService)
        {
            _definitenessService = definitenessService;
            _nounService = nounService;
            _verbService = verbService;
            _wordOrderService = wordOrderService;
            _pastTenseService = pastTenseService;
            _presentTenseService = presentTenseService;
            _perfectTenseService = perfectTenseService;
            _futureTenseService = futureTenseService;
        }
        public async Task<DisplayBasicSentenceDto> Handle(DisplayBasicSentenceQuery request, CancellationToken cancellationToken)
        {
            var sentence = new Sentence();

            sentence.SubjectNoun = await _nounService.GetAsync(request.SubjectId);
            sentence.SubjectNoun.GrammaticalNumber = request.SubjectGrammaticalNumber switch
            {
                "singular" => GrammaticalNumber.Singular,
                "plural" => GrammaticalNumber.Plural,
                _ => throw new InvalidEnumArgumentException()
            };
            sentence.SubjectNoun.Definiteness = request.SubjectDefiniteness switch
            {
                "definite" => Definiteness.Definite,
                "indefinite" => Definiteness.Indefinite,
                _ => throw new InvalidEnumArgumentException()
            };
            sentence.SubjectNoun = _nounService.GrammaticalNumberDisplayForm(sentence.SubjectNoun);
            sentence.SubjectNoun = _definitenessService.SetDefinitenessDisplayForm(sentence.SubjectNoun);

            sentence.Predicate = await _verbService.GetAsync(request.PredicateId);


            //Fix better please

            sentence.Tense = request.Tense switch
            {
                "present" => Tense.Present,
                "perfect" => Tense.Perfect,
                "future" => Tense.Future,
                "past" => Tense.Past,
                _ => throw new InvalidEnumArgumentException()
            };

            //



            sentence.Predicate = request.Tense switch
            {
                "present" => _presentTenseService.SetDisplayForm(sentence.Predicate),
                "past" => _pastTenseService.SetDisplayForm(sentence.Predicate),
                "perfect" => _perfectTenseService.SetDisplayForm(sentence.Predicate),
                "future" => _futureTenseService.SetDisplayForm(sentence.Predicate),
                _ => throw new InvalidEnumArgumentException()
            };
            sentence.StatementOrQuestion = request.StatementOrQuestion switch
            {
                "statement" => StatementOrQuestion.Statement,
                "question" => StatementOrQuestion.Question,
                _ => throw new InvalidEnumArgumentException()
            };
            sentence = await _wordOrderService.ToQuestionOrStatementAsync(sentence);
            sentence.DisplaySentence = char.ToUpper(sentence.DisplaySentence[0]) +
                                       sentence.DisplaySentence[1..];

            return sentence.ToDto();
        }
    }
}
