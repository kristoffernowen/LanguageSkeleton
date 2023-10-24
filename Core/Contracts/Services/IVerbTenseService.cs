using Core.Models.Words;

namespace Core.Contracts.Services
{
    public interface IVerbTenseService
    {
        Verb PresentTense(Verb verb);
        Verb PastTense(Verb verb);
        Verb FutureTense(Verb verb);
        Verb PerfectTense(Verb verb);
    }
}
