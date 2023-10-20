using Core.Models.Words;

namespace Core.Contracts.Services
{
    public interface IVerbService
    {
        public void CreateVerb(Verb verb);
        public List<Verb> GetAll();
    }
}
