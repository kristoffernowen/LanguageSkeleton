using global::Microsoft.AspNetCore.Components;
using Blazor.UI.Services.Nouns;
using LanguageSkeleton.Blazor.UI.Services.Base;

namespace Blazor.UI.Pages.Test
{
    public partial class Index
    {
        [Inject] private INounService NounService { get; set; }
        private List<GetAllNounsOutputDto> List { get; set; } = new List<GetAllNounsOutputDto>();
        private GetAllNounsOutputDto Noun { get; set; } = new GetAllNounsOutputDto();
        private GetNounOutputDto NewNoun { get; set; } = new GetNounOutputDto();
        
        

        private async Task HandleSubmit()
        {
            NewNoun = await NounService.Get(Noun.Id);
            var stopPoint = "";
        }

        protected override async Task OnInitializedAsync()
        {
            List = await NounService.Get();
        }
    }
}