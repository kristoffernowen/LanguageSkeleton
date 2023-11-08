using Application.Contracts.Services.Noun;
using LanguageSkeleton.Api.Dtos.Noun;
using Microsoft.AspNetCore.Mvc;

namespace LanguageSkeleton.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NounController : ControllerBase
    {
        private readonly INounService _nounService;

        public NounController(INounService nounService)
        {
            _nounService = nounService;
        }

        [HttpPost]
        public async Task Create(CreateNounInputDto dto)
        {
            await _nounService.CreateNounAsync(dto.ToModel());
        }

        [HttpGet]
        public async Task<List<GetAllNounsOutputDto>> GetNouns()
        {
            var result = await _nounService.GetAllAsync();

            return result.Select(n => n.ToDto()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<GetNounOutputDto> GetNoun(string id)
        {
            var noun = await _nounService.GetAsync(id);

            return noun.ToNounOutputDto();
        }
    }
}
