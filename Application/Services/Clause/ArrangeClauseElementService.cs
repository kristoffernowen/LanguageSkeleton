using Application.Contracts.Services.Noun;
using Domain.Enums;
using Domain.Models.Sentence;
using Domain.Models.Words;

namespace Application.Services.Clause
{
    public class ArrangeClauseElementService : IArrangeClauseElementService
    {
        public ClauseElement Subject(Sentence sentence)
        {
            var clauseElementSubject = new ClauseElement();
            switch (sentence.SubjectNoun.Definiteness)
            {
                case Definiteness.Indefinite when sentence.SubjectNoun.GrammaticalNumber == GrammaticalNumber.Singular:
                    clauseElementSubject.Words.Add(new Article()
                        {DisplayForm = $"{sentence.SubjectNoun.NounArticle}"});
                    break;
                case Definiteness.Indefinite when sentence.SubjectNoun.GrammaticalNumber == GrammaticalNumber.Plural:
                    clauseElementSubject.Words.Add(new Article(){DisplayForm = "några"});
                    break;
            }

            clauseElementSubject.Words.Add(sentence.SubjectNoun);
            foreach (var w in clauseElementSubject.Words)
            {
                clauseElementSubject.DisplayForm += $"{w.DisplayForm} ";
            }

            clauseElementSubject.DisplayForm = clauseElementSubject.DisplayForm.Remove(clauseElementSubject.DisplayForm.Length - 1);

            return clauseElementSubject;
        }
    }
}
