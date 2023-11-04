using Application.Contracts.Services.Sentence;
using Application.Dtos.Sentence.Input;
using Application.Dtos.Sentence.Output;
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
        public async Task<CreateSentenceOutputDto> Create(CreateSentenceInputDto dto)
        {
            var result = await _populateSentenceService.CreateSentenceBaseAsync(dto);

            return result;
        }
    }
}
