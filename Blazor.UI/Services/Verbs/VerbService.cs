using Blazor.UI.Services.Base;
using LanguageSkeleton.Blazor.UI.Services.Base;

namespace Blazor.UI.Services.Verbs
{
    public interface IVerbService
    {
        public Task<List<GetAllVerbsOutputDto>> Get();
        public Task<GetVerbOutputDto> Get(string id);
    }

    public class VerbService : BaseHttpService, IVerbService
    {
        public VerbService(IClient client) : base(client)
        {
        }
        public async Task<List<GetAllVerbsOutputDto>> Get()
        {
            var verbs = await _client.VerbAllAsync();
            return verbs.ToList();
        }

        public async Task<GetVerbOutputDto> Get(string id)
        {
            return await _client.VerbGETAsync(id);
        }
    }
}
