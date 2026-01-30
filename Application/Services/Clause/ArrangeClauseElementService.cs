using Application.Contracts.Repos;
using Application.Contracts.Services.Noun;
using Domain.Enums.Noun;
using Domain.Enums.Verb;
using Domain.Models.Sentence;
using Domain.Models.ValueObjects;
using Domain.Models.Words;

namespace Application.Services.Clause
{
    public class ArrangeClauseElementService(IVerbRepo verbRepo) : IArrangeClauseElementService
    {
        public ClauseElement Subject(Sentence sentence)
        {
            var clauseElement = new ClauseElement();

            if (sentence.SubjectForm.Definiteness == Definiteness.Indefinite)
            {
                clauseElement["article"] = sentence.SubjectForm.Definiteness switch
                {
                    Definiteness.Indefinite when sentence.SubjectForm.GrammaticalNumber == GrammaticalNumber.Singular =>
                        new Article() { DisplayForm = $"{sentence.SubjectForm.Lexem.NounArticle switch {NounArticle.en => "en", NounArticle.ett => "ett", _ => "Blä" } }", Id = "en" },
                    Definiteness.Indefinite when sentence.SubjectForm.GrammaticalNumber == GrammaticalNumber.Plural =>
                        new Article() { DisplayForm = "några", Id = "några" },
                    _ => clauseElement["article"]
                };
            }

            clauseElement["subject"] = sentence.SubjectForm;

            if (sentence.SubjectForm.Definiteness == Definiteness.Definite)
            {
                clauseElement.DisplayForm = $"{(clauseElement["subject"] as NounForm)!.SurfaceForm}";
            }
            else
            {
                try
                {
                    clauseElement.DisplayForm =
                        $"{clauseElement["article"].DisplayForm} {(clauseElement["subject"] as NounForm)!.SurfaceForm}";
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

            switch (sentence.Tense) // only need to handle perfect and future here, present and past are covered by verb one
            {
                case Tense.Perfect:
                    var have = await verbRepo.GetVerbFromPresentTenseAsync("har");
                    have.DisplayForm = have.PresentTense;
                    clauseElement["verb two"] = have;
                    break;
                case Tense.Future:
                    var shall = await verbRepo.GetVerbFromPresentTenseAsync("ska");
                    shall.DisplayForm = shall.PresentTense;
                    clauseElement["verb two"] = shall;
                break;
            }

            return clauseElement;
        }
    }
}
