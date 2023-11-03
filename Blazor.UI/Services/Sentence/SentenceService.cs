using Blazor.UI.Services.Base;
using LanguageSkeleton.Blazor.UI.Services.Base;

namespace Blazor.UI.Services.Sentence
{
    public interface ISentenceService
    {
        public Task<CreateSentenceOutputDto> Create(CreateSentenceInputDto dto);
    }

    public class SentenceService : BaseHttpService, ISentenceService
    {
        public SentenceService(IClient client) : base(client)
        {
        }

        public async Task<CreateSentenceOutputDto> Create(CreateSentenceInputDto dto)
        {
            return await _client.SentenceContentAsync(dto);
        }
    }
}
