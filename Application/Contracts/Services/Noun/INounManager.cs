using Application.Services.NounForms;

namespace Application.Contracts.Services.Noun
{
    public interface INounManager
    {
        IGrammaticalNumberService GrammaticalNumber { get; }
        IDefinitenessService DefinitenessService { get; }

    }
}
