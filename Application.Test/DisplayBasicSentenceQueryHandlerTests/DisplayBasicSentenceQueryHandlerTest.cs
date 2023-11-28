using Application.Contracts.Services.Noun;
using Application.Contracts.Services.Sentence;
using Application.Contracts.Services.Verb;
using Application.Features.BasicSentence.Queries.DisplayBasicSentence;
using Application.Services;
using Application.Services.Clause;
using Application.Test.Mock;
using System.Text.RegularExpressions;
using Application.Services.NounForms;

namespace Application.Test.DisplayBasicSentenceQueryHandlerTests
{
    public class DisplayBasicSentenceQueryHandlerTest
    {
        private readonly INounManager _nounManager = new NounManager(new GrammaticalNumber(), new Definiteness());
        private readonly ITenseManager _tenseManager = new TenseManagerFake();
        private readonly IVerbService _verbService = new VerbServiceFake();
        private readonly INounService _nounService = new NounServiceFake();
        private readonly IWordOrderService _wordOrderService = new WordOrderService(new ArrangeClauseElementService(new VerbServiceFake()));

        [Fact]
        public async void ShouldReturnBasicSentencePresentTense()
        {
            var handler = new DisplayBasicSentenceQueryHandler(_nounManager, _tenseManager,
                _wordOrderService, _verbService, _nounService);

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
            var handler = new DisplayBasicSentenceQueryHandler(_nounManager, _tenseManager,
                _wordOrderService, _verbService, _nounService);

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
