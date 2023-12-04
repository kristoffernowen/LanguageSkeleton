using Blazor.UI.Services.Base;
using LanguageSkeleton.Blazor.UI.Services.Base;

namespace Blazor.UI.Services.Verbs
{
    public interface IVerbService
    {
        public Task<List<GetVerbQueryDto>> Get();
        public Task<GetVerbByIdDto> Get(string id);
    }

    public class VerbService : BaseHttpService, IVerbService
    {
        public VerbService(IClient client) : base(client)
        {
        }
        public async Task<List<GetVerbQueryDto>> Get()
        {
            var verbs = await _client.VerbAllAsync();
            return verbs.ToList();
        }

        public async Task<GetVerbByIdDto> Get(string id)
        {
            return await _client.VerbGETAsync(id);
        }
    }
}
