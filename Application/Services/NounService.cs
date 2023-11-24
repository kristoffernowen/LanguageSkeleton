using System.ComponentModel;
using Application.Contracts.Repos;
using Application.Contracts.Services.Noun;
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
        public async Task CreateNounAsync(Noun noun)
        {
            await  _nounRepo.CreateNounAsync(noun);
        }

        public async Task<List<Noun>> GetAllAsync()
        {
            return await _nounRepo.GetAllNounsAsync();
        }

        public async Task<Noun> GetAsync(string id)
        {
            return await _nounRepo.GetNounAsync(id);
        }
    }
}
