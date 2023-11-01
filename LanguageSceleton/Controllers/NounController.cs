
using Domain.Contracts.Services.Noun;
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
        public void Create(CreateNounInputDto dto)
        {
            _nounService.CreateNoun(dto.ToModel());
        }

        [HttpGet]
        public List<GetAllNounsOutputDto> GetNouns()
        {
            return _nounService.GetAll().Select(n => n.ToDto()).ToList();
        }

        [HttpGet("{id}")]
        public GetNounOutputDto GetNoun(string id)
        {
            return _nounService.Get(id).ToNounOutputDto();
        }
    }
}
