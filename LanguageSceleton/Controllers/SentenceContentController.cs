using Domain.Contracts.Services.Sentence;
using LanguageSkeleton.Api.Dtos.Sentence;
using Microsoft.AspNetCore.Mvc;

namespace LanguageSkeleton.Api.Controllers
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
