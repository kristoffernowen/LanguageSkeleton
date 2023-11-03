using Domain.Contracts.Services.Noun;
using Domain.Contracts.Services.Sentence;
using Domain.Contracts.Services.Verb;
using Domain.Enums;
using Domain.Models.Sentence;

namespace Application.Services
{
    public class PopulateSentenceService : IPopulateSentenceService
    {
        private readonly IDefinitenessService _definitenessService;
        private readonly IGrammaticalNumberService _grammaticalNumberService;
        private readonly IVerbTenseService _verbTenseService;
        private readonly INounService _nounService;

        public PopulateSentenceService(IDefinitenessService definitenessService, IGrammaticalNumberService grammaticalNumberService,
            IVerbTenseService verbTenseService, INounService nounService)
        {
            _definitenessService = definitenessService;
            _grammaticalNumberService = grammaticalNumberService;
            _verbTenseService = verbTenseService;
            _nounService = nounService;
        }
        
        public Sentence CreateSentence(Sentence sentence)
        {
            var nounSubject = _nounService.Get(sentence.SubjectNoun.Id);

            sentence.SubjectNoun.BaseForm = nounSubject.BaseForm;


            if (sentence.SubjectNoun.GrammaticalNumber == GrammaticalNumber.Singular)
            {
                sentence.SubjectNoun = _grammaticalNumberService.Singular(sentence.SubjectNoun);
            }
            else
            {
                sentence.SubjectNoun = _grammaticalNumberService.Plural(sentence.SubjectNoun);
            }

            if (sentence.SubjectNoun.Definiteness == Definiteness.Definite)
            {
                sentence.SubjectNoun = _definitenessService.Definite(sentence.SubjectNoun);
            }
            else
            {
                sentence.SubjectNoun = _definitenessService.Indefinite(sentence.SubjectNoun);
            }

            if (sentence.Tense == Tense.Present)
            {
                sentence.Predicate = _verbTenseService.PresentTense(sentence.Predicate);
            }
            else if(sentence.Tense == Tense.Past)
            {
                sentence.Predicate = _verbTenseService.PastTense(sentence.Predicate);
            }

            if (sentence.StatementOrQuestion == StatementOrQuestion.Statement)
            {
                sentence.DisplaySentence = $"{sentence.SubjectNoun.DisplayForm} {sentence.Predicate.DisplayForm}.";
            }
            else
            {
                sentence.DisplaySentence = $"{sentence.Predicate.DisplayForm} {sentence.SubjectNoun.DisplayForm}?";

            }
            return sentence;
        }

        public Sentence AddObjectToSentence(Sentence sentence)
        {
            throw new NotImplementedException();
        }

        public Sentence RemoveObjectFromSentence(Sentence sentence)
        {
            throw new NotImplementedException();
        }
    }
}
