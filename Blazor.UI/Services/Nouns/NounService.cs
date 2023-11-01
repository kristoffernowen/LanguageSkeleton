using Blazor.UI.Services.Base;
using LanguageSkeleton.Blazor.UI.Services.Base;

namespace Blazor.UI.Services.Nouns
{
    public interface INounService
    {
        public Task<List<GetAllNounsOutputDto>> Get();
        public Task<GetNounOutputDto> Get(string id);
    }

    public class NounService : BaseHttpService, INounService
    {
        public NounService(IClient client) : base(client)
        {
        }

        public async Task<List<GetAllNounsOutputDto>> Get()
        {
            var list = await _client.NounAllAsync();

            return list.ToList();
        }

        public async Task<GetNounOutputDto> Get(string id)
        {
            return await _client.NounGETAsync(id);
        }
    }
}
