using Core.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanguageSceleton.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentenceContentController : ControllerBase
    {
        private readonly IPopulateSentenceService populateSentenceService;
    }
}
