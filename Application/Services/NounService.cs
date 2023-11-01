using Domain.Contracts.Repos;
using Domain.Contracts.Services.Noun;
using Domain.Models.Words;

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

        public Noun Get(string id)
        {
            return _nounRepo.GetNoun(id);
        }
    }
}
