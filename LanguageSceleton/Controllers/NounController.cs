using Application.Features.Nouns.Commands;
using Application.Features.Nouns.Queries.GetAllNouns;
using Application.Features.Nouns.Queries.GetNoun;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LanguageSkeleton.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NounController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NounController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task Create(CreateNounCommand command)
        {
            await _mediator.Send(command);
        }
        
        [HttpGet]
        public async Task<List<GetAllNounsQueryDto>> GetNouns()
        {
            return await _mediator.Send(new GetAllNounsQuery());
        }

        [HttpGet("{id}")]
        public async Task<GetNounQueryDto> GetNoun(string id)
        {
            return await _mediator.Send(new GetNounQuery(id));
        }
    }
}
