using Blazor.UI.Services.Verbs;
using LanguageSkeleton.Blazor.UI.Services.Base;
using Microsoft.AspNetCore.Components;

namespace Blazor.UI.Pages.Verbs
{
    public partial class Index
    {
        [Inject] private IVerbService _verbService { get; set; }

        public List<GetVerbQueryDto> Verbs { get; set; } = new List<GetVerbQueryDto>();

        protected override async Task OnInitializedAsync()
        {
            Verbs = await _verbService.Get();
        }
    }
}