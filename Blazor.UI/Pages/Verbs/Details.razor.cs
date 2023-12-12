using Blazor.UI.Services.Verbs;
using LanguageSkeleton.Blazor.UI.Services.Base;
using Microsoft.AspNetCore.Components;

namespace Blazor.UI.Pages.Verbs;

public partial class Details
{
    [Inject] private NavigationManager _navigationManager { get; set; }
    [Inject] private IVerbService _verbService { get; set; }
    [Parameter] public string Id { get; set; }
    public GetVerbByIdDto GetVerbQueryDto { get; set; } = new GetVerbByIdDto() {Id = "", PresentTense = ""};

    protected override async Task OnInitializedAsync()
    {
        GetVerbQueryDto = await _verbService.Get(Id);
    }

    private void ToIndex()
    {
        _navigationManager.NavigateTo("/verbs/");
    }
}