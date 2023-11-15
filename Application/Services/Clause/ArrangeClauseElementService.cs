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

            if (sentence.SubjectNoun.Definiteness == Definiteness.Indefinite)
            {
                clauseElement["article"] = sentence.SubjectNoun.Definiteness switch
                {
                    Definiteness.Indefinite when sentence.SubjectNoun.GrammaticalNumber == GrammaticalNumber.Singular =>
                        new Article() { DisplayForm = $"{sentence.SubjectNoun.NounArticle}", Id = "en" },
                    Definiteness.Indefinite when sentence.SubjectNoun.GrammaticalNumber == GrammaticalNumber.Plural =>
                        new Article() { DisplayForm = "några", Id = "några" },
                    _ => clauseElement["article"]
                };
            }

            clauseElement["subject"] = sentence.SubjectNoun;

            if (sentence.SubjectNoun.Definiteness == Definiteness.Definite)
            {
                clauseElement.DisplayForm = $"{clauseElement["subject"].DisplayForm}";
            }
            else
            {
                try
                {
                    clauseElement.DisplayForm =
                        $"{clauseElement["article"].DisplayForm} {clauseElement["subject"].DisplayForm}";
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
            var clauseElement = new ClauseElement
            {
                ["verb one"] = sentence.Predicate
            };

            switch (sentence.Tense)
            {
                case Tense.Perfect:
                    var have = await _verbService.GetByPresentTense("har");
                    have.DisplayForm = have.PresentTense;
                    clauseElement["verb two"] = have;
                    break;
                case Tense.Future:
                    var shall = await _verbService.GetByPresentTense("ska");
                    shall.DisplayForm = shall.PresentTense;
                    clauseElement["verb two"] = shall;
                break;
            }

            return clauseElement;
        }
    }
}
