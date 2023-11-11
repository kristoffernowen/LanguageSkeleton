using Application.Contracts.Services.Sentence;
using Application.Dtos.Sentence.Input;
using Application.Dtos.Sentence.Output;
using Application.Features.BasicSentence.Queries.DisplayBasicSentence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LanguageSkeleton.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentenceContentController : ControllerBase
    {
        private readonly IPopulateSentenceService _populateSentenceService;
        private readonly IMediator _mediator;

        public SentenceContentController(IPopulateSentenceService populateSentenceService, IMediator mediator)
        {
            _populateSentenceService = populateSentenceService;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<DisplayBasicSentenceDto> Create(DisplayBasicSentenceQuery request)
        {
            var result = await _mediator.Send(request);

            // var result = await _populateSentenceService.CreateSentenceBaseAsync(dto);

            return result;
        }
    }
}
