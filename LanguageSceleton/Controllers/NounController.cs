using Core.Contracts.Services;
using Core.Models.Words;
using LanguageSceleton.Api.Dtos.Noun;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanguageSceleton.Api.Controllers
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
    }
}
