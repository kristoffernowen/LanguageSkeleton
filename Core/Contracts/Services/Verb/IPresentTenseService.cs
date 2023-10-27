using Core.Models.Words;

namespace Core.Contracts.Services.Verb
{
    public interface IPresentTenseService
    {
        public Models.Words.Verb PresentTense(Models.Words.Verb verb);
    }
}
