using LanguageSkeleton.Blazor.UI.Services.Base;

namespace Blazor.UI.Services.Base
{
    public class BaseHttpService
    {
        protected readonly IClient _client;

        public BaseHttpService(IClient client)
        {
            _client = client;
        }
    }
}
