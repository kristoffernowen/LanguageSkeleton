using System.ComponentModel;
using Application.Contracts.Services.Noun;
using Application.Contracts.Services.Sentence;
using Application.Contracts.Services.Verb;
using Application.Dtos.Sentence.Input;
using Application.Dtos.Sentence.Output;
using Domain.Enums;
using Domain.Models.Sentence;

namespace Application.Services
{
    public class PopulateSentenceService : IPopulateSentenceService
    {
        private readonly IDefinitenessService _definitenessService;
        private readonly IGrammaticalNumberService _grammaticalNumberService;
        private readonly INounService _nounService;
        private readonly IVerbService _verbService;
        private readonly IWordOrderService _wordOrderService;
        private readonly IPastTenseService _pastTenseService;
        private readonly IPresentTenseService _presentTenseService;
        private readonly IPerfectTenseService _perfectTenseService;
        private readonly IFutureTenseService _futureTenseService;

        public PopulateSentenceService(IDefinitenessService definitenessService, IGrammaticalNumberService grammaticalNumberService,
            INounService nounService, IVerbService verbService, IWordOrderService wordOrderService,
            IPastTenseService pastTenseService, IPresentTenseService presentTenseService, IPerfectTenseService perfectTenseService,
            IFutureTenseService futureTenseService)
        {
            _definitenessService = definitenessService;
            _grammaticalNumberService = grammaticalNumberService;
            _nounService = nounService;
            _verbService = verbService;
            _wordOrderService = wordOrderService;
            _pastTenseService = pastTenseService;
            _presentTenseService = presentTenseService;
            _perfectTenseService = perfectTenseService;
            _futureTenseService = futureTenseService;
        }
        
        public async Task<CreateSentenceOutputDto> CreateSentenceBaseAsync(CreateSentenceInputDto dto)
        {
            var sentence = new Sentence();
            sentence.SubjectNoun = await _nounService.GetAsync(dto.SubjectNounInput.Id);
            sentence.SubjectNoun.GrammaticalNumber = dto.SubjectNounInput.GrammaticalNumber switch
            {
                "singular" => GrammaticalNumber.Singular,
                "plural" => GrammaticalNumber.Plural,
                _ => throw new InvalidEnumArgumentException()
            };
            sentence.SubjectNoun.Definiteness = dto.SubjectNounInput.Definiteness switch
            {
                "definite" => Definiteness.Definite,
                "indefinite" => Definiteness.Indefinite,
                _ => throw new InvalidEnumArgumentException()
            };
            sentence.SubjectNoun = _nounService.GrammaticalNumberDisplayForm(sentence.SubjectNoun);
            sentence.SubjectNoun = _definitenessService.SetDefinitenessDisplayForm(sentence.SubjectNoun);

            sentence.Predicate = await _verbService.GetAsync(dto.Predicate.Id);


            //Fix better please

            sentence.Tense = dto.Tense switch
            {
                "present" => Tense.Present,
                "perfect" => Tense.Perfect,
                "future" => Tense.Future,
                "past" => Tense.Past,
                _ => throw new InvalidEnumArgumentException()
            };

            //



            sentence.Predicate = dto.Tense switch
            {
                "present" => _presentTenseService.SetDisplayForm(sentence.Predicate),
                "past" => _pastTenseService.SetDisplayForm(sentence.Predicate),                     
                "perfect" => _perfectTenseService.SetDisplayForm(sentence.Predicate),
                "future" => _futureTenseService.SetDisplayForm(sentence.Predicate),
                _ => throw new InvalidEnumArgumentException()
            };
            sentence.StatementOrQuestion = dto.StatementOrQuestion switch
            {
                "statement" => StatementOrQuestion.Statement,
                "question" => StatementOrQuestion.Question,
                _ => throw new InvalidEnumArgumentException()
            };
            sentence = await _wordOrderService.ToQuestionOrStatementAsync(sentence);
            sentence.DisplaySentence = char.ToUpper(sentence.DisplaySentence[0]) +
                                            sentence.DisplaySentence[1..];

            return sentence.ToCreateOutputDto();
        }

        public async Task<Sentence> AddObjectToSentence(Sentence sentence)
        {
            throw new NotImplementedException();
        }

        public async Task<Sentence> RemoveObjectFromSentence(Sentence sentence)
        {
            throw new NotImplementedException();
        }
    }
}
