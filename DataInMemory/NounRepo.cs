using Application.Contracts.Repos;
using AutoMapper;
using Domain.Models.Words;

namespace DataInMemory
{
    public class NounRepo : INounRepo 
    {
        public Task CreateNounAsync(Noun noun)
        {
            throw new NotImplementedException();
        }

        public async Task<Noun> GetNounAsync(string id)
        {
            return NounsInMemory.Nouns.FirstOrDefault(x => x.Id == id);
        }

        public Task<List<Noun>> GetAllNounsAsync()
        {
            return Task.FromResult(NounsInMemory.Nouns.ToList());
        }
    }

    public class VerbRepo : IVerbRepo
    {
        public Task CreateVerbAsync(Verb verb)
        {
            throw new NotImplementedException();
        }

        public Task<Verb> GetVerbAsync(string id)
        {
            return Task.FromResult(VerbsInMemory.Verbs.FirstOrDefault(x => x.Id == id));
        }

        public Task<Verb> GetVerbFromPresentTenseAsync(string presentTense)
        {
            var verb = VerbsInMemory.Verbs.FirstOrDefault(x => x.PresentTense == presentTense);

            return Task.FromResult(verb);
        }

        public Task<List<Verb>> GetAllVerbAsync()
        {
            return Task.FromResult(VerbsInMemory.Verbs.ToList());
        }
    }
}
