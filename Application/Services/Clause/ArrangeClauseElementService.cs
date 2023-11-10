using Application.Contracts.Services.Noun;
using Application.Contracts.Services.Verb;
using Domain.Enums;
using Domain.Models.Sentence;
using Domain.Models.Words;

namespace Application.Services.Clause
{
    public class ArrangeClauseElementService : IArrangeClauseElementService
    {
        private readonly IVerbService _verbService;

        public ArrangeClauseElementService(IVerbService verbService)
        {
            _verbService = verbService;
        }

        public ClauseElement Subject(Sentence sentence)
        {
            var clauseElement = new ClauseElement();

            switch (sentence.SubjectNoun.Definiteness)
            {
                case Definiteness.Indefinite when sentence.SubjectNoun.GrammaticalNumber == GrammaticalNumber.Singular:
                    clauseElement.DictionaryOfWords.Add("article", new Article(){DisplayForm = $"{sentence.SubjectNoun.NounArticle}", Id = "en"});
                    break;
                case Definiteness.Indefinite when
                    sentence.SubjectNoun.GrammaticalNumber == GrammaticalNumber.Plural:
                    clauseElement.DictionaryOfWords.Add("article", new Article() { DisplayForm = "några", Id = "några"});
                    break;
            }

            clauseElement.DictionaryOfWords.Add("subject", sentence.SubjectNoun);

            if (sentence.SubjectNoun.Definiteness == Definiteness.Definite)
            {
                clauseElement.DisplayForm = $"{clauseElement.DictionaryOfWords["subject"].DisplayForm}";
            }
            else
            {
                try
                {
                    clauseElement.DisplayForm =
                        $"{clauseElement.DictionaryOfWords["article"].DisplayForm} {clauseElement.DictionaryOfWords["subject"].DisplayForm}";
                }
                catch (Exception e)
                {
                    Console.WriteLine("could not set up indefinite subject clause with article:" + e);
                    throw;
                }
            }

            return clauseElement;
        }

        public async Task<ClauseElement> Predicate(Sentence sentence)
        {
            var clauseElement = new ClauseElement();

            clauseElement.DictionaryOfWords.Add("verb one", sentence.Predicate);

            // var comes = await _verbService.GetAsync("72b8f2b2-5bce-463d-9393-dbb7939f4135"); // kommer
            // comes.DisplayForm = comes.PresentTense;

            switch (sentence.Tense)
            {
                case Tense.Perfect:
                    var have = await _verbService.GetAsync("5079b3c5-3404-4a0f-bb10-302d49deb62a");
                    have.DisplayForm = have.PresentTense;
                    clauseElement.DictionaryOfWords.Add("verb two", have);
                    break;
                case Tense.Future:
                    var shall = await _verbService.GetAsync("a2a39778-35ea-499a-b6d3-4b69ceaeaa52"); // ska
                    shall.DisplayForm = shall.PresentTense;
                    clauseElement.DictionaryOfWords.Add("verb two", shall);
                break;
            }

            return clauseElement;
        }
    }
}
