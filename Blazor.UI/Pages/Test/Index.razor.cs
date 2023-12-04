using AutoMapper;
using Blazor.UI.Models.BasicSentence;
using global::Microsoft.AspNetCore.Components;
using Blazor.UI.Services.Nouns;
using Blazor.UI.Services.Sentence;
using Blazor.UI.Services.Verbs;
using LanguageSkeleton.Blazor.UI.Services.Base;

namespace Blazor.UI.Pages.Test
{
    public partial class Index
    {
        [Inject] private INounService NounService { get; set; }
        [Inject] private IVerbService VerbService { get; set; }
        [Inject] private ISentenceService SentenceService { get; set; }
        [Inject] private IMapper _mapper { get; set; }
        private List<GetAllNounsQueryDto> Nouns { get; set; } = new List<GetAllNounsQueryDto>();
        private List<GetVerbQueryDto> Verbs { get; set; } = new List<GetVerbQueryDto>();

        private DisplayBasicSentenceVm DisplaySentence = new DisplayBasicSentenceVm()
        {
            Tense = "",
            StatementOrQuestion = "",
            SubjectId = "",
            SubjectDefiniteness = "",
            SubjectGrammaticalNumber = "",
            PredicateId = "",
            PredicatePresentTense = "",
            PredicateVerbConjugation = "",
            DisplaySentence = ""
        };

        private async Task HandleSubmit()
        {
            DisplaySentence = await SentenceService.DisplayBasicSentence(_mapper.Map<DisplayBasicSentenceQuery>(DisplaySentence));
        }

        protected override async Task OnInitializedAsync()
        {
            Nouns = await NounService.Get();
            Verbs = await VerbService.Get();
        }
    }
}