using AutoMapper;
using Blazor.UI.Models.BasicSentence;
using Blazor.UI.Services.Base;
using LanguageSkeleton.Blazor.UI.Services.Base;

namespace Blazor.UI.Services.Sentence
{
    public interface ISentenceService
    {
        public Task<DisplayBasicSentenceVm> DisplayBasicSentence(DisplayBasicSentenceQuery request);
    }

    public class SentenceService : BaseHttpService, ISentenceService
    {
        private readonly IMapper _mapper;

        public SentenceService(IClient client, IMapper mapper) : base(client)
        {
            _mapper = mapper;
        }

        public async Task<DisplayBasicSentenceVm> DisplayBasicSentence(DisplayBasicSentenceQuery request)
        {
            var dto = await _client.SentenceContentAsync(request);
            return _mapper.Map<DisplayBasicSentenceVm>(dto);
        }
    }
}
