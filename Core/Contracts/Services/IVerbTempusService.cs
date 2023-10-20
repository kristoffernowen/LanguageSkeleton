using Core.Models.Words;

namespace Core.Contracts.Services
{
    public interface IVerbTempusService
    {
        Verb PresentTense(Verb verb);
    }
}
