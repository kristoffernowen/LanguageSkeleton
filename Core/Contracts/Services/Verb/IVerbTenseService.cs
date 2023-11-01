namespace Domain.Contracts.Services.Verb
{
    public interface IVerbTenseService
    {
        Models.Words.Verb PresentTense(Models.Words.Verb verb);
        Models.Words.Verb PastTense(Models.Words.Verb verb);
        Models.Words.Verb FutureTense(Models.Words.Verb verb);
        Models.Words.Verb PerfectTense(Models.Words.Verb verb);
    }
}
