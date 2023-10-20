using Core.Contracts.Repos;
using Core.Contracts.Services;
using Core.Models.Words;

namespace Application.Services
{
    public class NounService : INounService
    {
        private readonly INounRepo _nounRepo;

        public NounService(INounRepo nounRepo)
        {
            _nounRepo = nounRepo;
        }
        public void CreateNoun(Noun noun)
        {
            _nounRepo.CreateNoun(noun);
        }

        public List<Noun> GetAll()
        {
            return _nounRepo.GetAllNouns();
        }
    }
}
