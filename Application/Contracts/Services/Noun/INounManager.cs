namespace Application.Contracts.Services.Noun
{
    public interface INounManager
    {
        INounService NounService { get; }
        IDefinitenessService DefinitenessService { get; }

    }
}
