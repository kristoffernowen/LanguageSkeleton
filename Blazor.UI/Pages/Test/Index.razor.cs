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
        private List<GetAllNounsOutputDto> Nouns { get; set; } = new List<GetAllNounsOutputDto>();
        private List<GetAllVerbsOutputDto> Verbs { get; set; } = new List<GetAllVerbsOutputDto>();
        private CreateSentenceInputDto CreateSentenceInput { get; } = new CreateSentenceInputDto()
        {
            Predicate = new CreateSentenceVerbInputDto()
            {
                PresentTense = "",
                Id = "",
                VerbConjugation = ""
            },
            SubjectNounInput = new CreateSentenceNounInputDto()
            {
                Id = "",
                Definiteness = "",
                GrammaticalNumber = ""
            },
            StatementOrQuestion = "",
            Tense = ""
        };
        private CreateSentenceOutputDto DisplayCreatedSentence { get; set; } = new CreateSentenceOutputDto()
        {
            SubjectNoun = new CreateSentenceNounOutputDto()
            {
                Definiteness = "definite",
                GrammaticalNumber = "singular",
                Id = "",
                DisplayForm = ""
            },
            Predicate = new CreateSentenceVerbOutputDto()
            {
                DisplayForm = "",
                Id = "",
                PresentTense = "",
                VerbConjugation = ""
            } ,
            StatementOrQuestion = "",
            Tense = "",
            DisplaySentence = ""
        };

        private async Task HandleSubmit()
        {
            DisplayCreatedSentence = await SentenceService.Create(CreateSentenceInput);
        }

        protected override async Task OnInitializedAsync()
        {
            Nouns = await NounService.Get();
            Verbs = await VerbService.Get();
        }
    }
}