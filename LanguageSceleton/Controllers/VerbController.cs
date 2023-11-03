using Application.Contracts.Services.Verb;
using LanguageSkeleton.Api.Dtos.Verb;
using Microsoft.AspNetCore.Mvc;

namespace LanguageSkeleton.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerbController : ControllerBase
    {
        private readonly IVerbService _verbService;

        public VerbController(IVerbService verbService)
        {
            _verbService = verbService;
        }

        [HttpPost]
        public void CreateVerb(CreateVerbInputDto dto)
        {
            _verbService.CreateVerbAsync(dto.ToModel());
        }

        [HttpGet]
        public async Task<List<GetAllVerbsOutputDto>> GetAllVerbs()
        {
            var verbs = await _verbService.GetAllAsync();

            return verbs.Select(v => v.ToDto()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<GetVerbOutputDto> GetNoun(string id)
        {
            var verb = await _verbService.GetAsync(id);
            return verb.ToGetVerbOutputDto();
        }
    }
}
