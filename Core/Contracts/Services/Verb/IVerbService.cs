using Core.Models.Words;

namespace Core.Contracts.Services.Verb
{
    public interface IVerbService
    {
        public void CreateVerb(Models.Words.Verb verb);
        public List<Models.Words.Verb> GetAll();
    }
}
