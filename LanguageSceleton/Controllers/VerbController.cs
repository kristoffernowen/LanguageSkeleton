using Application.Features.Verbs.Commands.CreateVerb;
using Application.Features.Verbs.Queries.GetVerbById;
using Application.Features.Verbs.Queries.GetVerbs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanguageSkeleton.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerbController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VerbController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<List<GetVerbQueryDto>> GetAllVerbs()
        {
            return await _mediator.Send(new GetVerbQuery());
        }

        [HttpGet("{id}")]
        public async Task<GetVerbByIdDto> GetVerb(string id)
        {
            return await _mediator.Send(new GetVerbByIdQuery(id));
        }

        [HttpPost]
        public async Task CreateVerb(CreateVerbCommand request)
        {
            await _mediator.Send(request);
        }
    }
}
