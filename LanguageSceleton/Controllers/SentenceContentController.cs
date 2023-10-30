using Core.Contracts.Services.Sentence;
using LanguageSceleton.Api.Dtos.Sentence;
using Microsoft.AspNetCore.Mvc;

namespace LanguageSceleton.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentenceContentController : ControllerBase
    {
        private readonly IPopulateSentenceService _populateSentenceService;

        public SentenceContentController(IPopulateSentenceService populateSentenceService)
        {
            _populateSentenceService = populateSentenceService;
        }

        [HttpPost]
        public IActionResult Create(CreateSentenceInputDto dto)
        {
            var result = _populateSentenceService.CreateSentence(dto.ToModel());

            return Ok(result);
        }
    }
}
