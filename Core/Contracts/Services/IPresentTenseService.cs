using Core.Models.Words;

namespace Core.Contracts.Services
{
    public interface IPresentTenseService
    {
        public Verb PresentTense(Verb verb);
    }
}
