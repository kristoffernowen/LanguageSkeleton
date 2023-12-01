﻿using Application.Contracts.Repos;
using Application.Contracts.Services.Noun;
using Application.Contracts.Services.Sentence;
using Application.Contracts.Services.Verb;
using MediatR;

namespace Application.Features.BasicSentence.Queries.DisplayBasicSentence
{
    public class DisplayBasicSentenceQueryHandler : IRequestHandler<DisplayBasicSentenceQuery, DisplayBasicSentenceDto>
    {
        private readonly INounManager _nounManager;
        private readonly ITenseManager _tenseManager;
        private readonly IWordOrderService _wordOrderService;
        private readonly INounService _nounService;
        private readonly IVerbRepo _verbRepo;


        public DisplayBasicSentenceQueryHandler(INounManager nounManager, ITenseManager tenseManager, IWordOrderService wordOrderService, INounService nounService, IVerbRepo verbRepo)
        {
            _nounManager = nounManager;
            _tenseManager = tenseManager;
            _wordOrderService = wordOrderService;
            _nounService = nounService;
            _verbRepo = verbRepo;
        }
        public async Task<DisplayBasicSentenceDto> Handle(DisplayBasicSentenceQuery request, CancellationToken cancellationToken)
        {
            var sentence = request.ToSentence(await _nounService.GetAsync(request.SubjectId), await _verbRepo.GetVerbAsync(request.PredicateId));

            sentence.SubjectNoun = _nounManager.SetDisplayForm(sentence.SubjectNoun);
            sentence.Predicate = _tenseManager.SetDisplayForm(sentence.Tense, sentence.Predicate);
            sentence = await _wordOrderService.ToQuestionOrStatementAsync(sentence);
            sentence.DisplaySentence = char.ToUpper(sentence.DisplaySentence[0]) +
                                       sentence.DisplaySentence[1..];

            return sentence.ToDto();
        }
    }
}
