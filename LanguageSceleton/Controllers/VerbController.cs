using Domain.Contracts.Services.Verb;
using LanguageSkeleton.Api.Dtos.Verb;
using Microsoft.AspNetCore.Http;
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
            _verbService.CreateVerb(dto.ToModel());
        }

        [HttpGet]
        public List<GetAllVerbsOutputDto> GetAllVerbs()
        {
            return _verbService.GetAll().Select(v => v.ToDto()).ToList();
        }

        [HttpGet("{id}")]
        public GetVerbOutputDto GetNoun(string id)
        {
            return _verbService.Get(id).ToGetVerbOutputDto();
        }
    }
}
