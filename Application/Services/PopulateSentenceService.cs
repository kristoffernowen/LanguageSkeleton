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
        private readonly IQuestionOrStatementService _questionOrStatementService;
        private readonly IPastTenseService _pastTenseService;
        private readonly IPresentTenseService _presentTenseService;

        public PopulateSentenceService(IDefinitenessService definitenessService, IGrammaticalNumberService grammaticalNumberService,
            INounService nounService, IVerbService verbService, IQuestionOrStatementService questionOrStatementService,
            IPastTenseService pastTenseService, IPresentTenseService presentTenseService)
        {
            _definitenessService = definitenessService;
            _grammaticalNumberService = grammaticalNumberService;
            _nounService = nounService;
            _verbService = verbService;
            _questionOrStatementService = questionOrStatementService;
            _pastTenseService = pastTenseService;
            _presentTenseService = presentTenseService;
        }
        
        public async Task<CreateSentenceOutputDto> CreateSentenceAsync(CreateSentenceInputDto sentence)
        {
            var sentenceModel = new Sentence();
            sentenceModel.SubjectNoun = await _nounService.GetAsync(sentence.SubjectNounInput.Id);
            sentenceModel.SubjectNoun.GrammaticalNumber = sentence.SubjectNounInput.GrammaticalNumber switch
            {
                "singular" => GrammaticalNumber.Singular,
                "plural" => GrammaticalNumber.Plural,
                _ => throw new InvalidEnumArgumentException()
            };
            sentenceModel.SubjectNoun.Definiteness = sentence.SubjectNounInput.Definiteness switch
            {
                "definite" => Definiteness.Definite,
                "indefinite" => Definiteness.Indefinite,
                _ => throw new InvalidEnumArgumentException()
            };
            sentenceModel.SubjectNoun = _nounService.GrammaticalNumberDisplayForm(sentenceModel.SubjectNoun);
            sentenceModel.SubjectNoun = _definitenessService.SetDefinitenessDisplayForm(sentenceModel.SubjectNoun);

            sentenceModel.Predicate = await _verbService.GetAsync(sentence.Predicate.Id);
            sentenceModel.Predicate = sentence.Tense switch
            {
                "present" => _presentTenseService.PresentTense(sentenceModel.Predicate),
                "past" => _pastTenseService.PastTense(sentenceModel.Predicate),
                _ => throw new InvalidEnumArgumentException()
            };
            sentenceModel.StatementOrQuestion = sentence.StatementOrQuestion switch
            {
                "statement" => StatementOrQuestion.Statement,
                "question" => StatementOrQuestion.Question,
                _ => throw new InvalidEnumArgumentException()
            };
            sentenceModel = await _questionOrStatementService.ToQuestionOrStatementAsync(sentenceModel);
            sentenceModel.DisplaySentence = char.ToUpper(sentenceModel.DisplaySentence[0]) +
                                            sentenceModel.DisplaySentence[1..];

            return sentenceModel.ToCreateOutputDto();
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
