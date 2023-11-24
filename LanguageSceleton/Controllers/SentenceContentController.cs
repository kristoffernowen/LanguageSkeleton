using Application.Features.BasicSentence.Queries.DisplayBasicSentence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LanguageSkeleton.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentenceContentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SentenceContentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<DisplayBasicSentenceDto> Create(DisplayBasicSentenceQuery request)
        {
            var result = await _mediator.Send(request);

            return result;
        }
    }
}
