using Application.Contracts.Services.Noun;
using Application.Contracts.Services.Sentence;
using Application.Contracts.Services.Verb;
using Application.Features.BasicSentence.Queries.DisplayBasicSentence;
using Application.Services;
using Application.Services.Clause;
using Application.Services.NounForms;
using Application.Services.VerbTenses;
using Application.Test.Mock;
using System.Text.RegularExpressions;

namespace Application.Test.DisplayBasicSentenceQueryHandlerTests
{
    public class DisplayBasicSentenceQueryHandlerTest
    {
        private readonly IDefinitenessService _definitenessService;
        private readonly INounService _nounService;
        private readonly IVerbService _verbService;
        private readonly IWordOrderService _wordOrderService;
        private readonly IPastTenseService _pastTenseService;
        private readonly IPresentTenseService _presentTenseService;
        private readonly IPerfectTenseService _perfectTenseService;
        private readonly IFutureTenseService _futureTenseService;

        public DisplayBasicSentenceQueryHandlerTest()
        {
            _definitenessService = new DefinitenessService();
            _nounService = new NounServiceFake();
            _verbService = new VerbServiceFake();
            _wordOrderService = new WordOrderService(new ArrangeClauseElementService(new VerbServiceFake()));
            _pastTenseService = new PastTenseService();
            _presentTenseService = new PresentTenseService();
            _perfectTenseService = new PerfectTenseService();
            _futureTenseService = new FutureTenseService();
        }

        [Fact]
        public async void ShouldReturnBasicSentencePresentTense()
        {
            var handler = new DisplayBasicSentenceQueryHandler(_definitenessService, _nounService, _verbService,
                _wordOrderService
                , _pastTenseService, _presentTenseService, _perfectTenseService, _futureTenseService);

            var request = new DisplayBasicSentenceQuery()
            {
                Tense = "present",
                StatementOrQuestion = "statement",
                SubjectId = "495a642f-c518-4b31-a91f-5586a0221694",
                SubjectDefiniteness = "definite",
                SubjectGrammaticalNumber = "singular",
                PredicateId = "9bd47607 - 3e7d - 4780 - b4c4 - 0cf03e9167ad",
                PredicatePresentTense = "pratar",
                PredicateVerbConjugation = "ArVerb"
            };

            var result = await handler.Handle(request, CancellationToken.None);
            var actual = result.DisplaySentence;
            const string expected = "Flickan pratar.";
            var actualAccountForWeirdSpaceDifference = Regex.Replace(actual, @"\s+", " ");
            var expectedAccountForWeirdSpaceDifference = Regex.Replace(expected, @"\s+", " ");
            
            Assert.Equal(expectedAccountForWeirdSpaceDifference, actualAccountForWeirdSpaceDifference);
        }

        [Fact]
        public async void ShouldReturnBasicSentencePerfectTenseAsQuestion()
        {
            var handler = new DisplayBasicSentenceQueryHandler(_definitenessService, _nounService, _verbService,
                _wordOrderService
                , _pastTenseService, _presentTenseService, _perfectTenseService, _futureTenseService);

            var request = new DisplayBasicSentenceQuery()
            {
                Tense = "perfect",
                StatementOrQuestion = "question",
                SubjectId = "495a642f-c518-4b31-a91f-5586a0221694",
                SubjectDefiniteness = "definite",
                SubjectGrammaticalNumber = "singular",
                PredicateId = "601e8d14-6152-4a48-9065-0b6be35a8773",
                PredicatePresentTense = "flyger",
                PredicateVerbConjugation = "StrongErVerb"
            };

            var result = await handler.Handle(request, CancellationToken.None);
            var actual = result.DisplaySentence;
            var expected = "Har flickan flugit?";
            var actualAccountForWeirdSpaceDifference = Regex.Replace(actual, @"\s+", " ");
            var expectedAccountForWeirdSpaceDifference = Regex.Replace(expected, @"\s+", " ");

            Assert.Equal(expectedAccountForWeirdSpaceDifference, actualAccountForWeirdSpaceDifference);
        }
    }

    
}
