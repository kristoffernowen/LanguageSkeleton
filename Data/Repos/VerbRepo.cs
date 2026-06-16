using Application.Contracts.Repos;
using AutoMapper;
using Data.PersistenceEntities;
using Domain.Models.Words;
using Microsoft.EntityFrameworkCore;

namespace Data.Repos
{
    public class VerbRepo(SqlContext context, IMapper mapper) : IVerbRepo
    {
        public async Task CreateAsync(Verb verb)
        {
            verb.Id = Guid.NewGuid().ToString();

            context.Verbs.Add(mapper.Map<VerbEntity>(verb));
            await context.SaveChangesAsync();
        }

        public async Task<Verb> GetByIdAsync(string id)
        {
            var result = await context.Verbs.FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<Verb>(result);
        }

        public async Task<Verb> GetFromPresentTenseAsync(string presentTense)
        {
            var result = await context.Verbs.FirstOrDefaultAsync(v => v.PresentTense == presentTense);

            return mapper.Map<Verb>(result);
        }


        public async Task<List<Verb>> GetAsync()
        {
            var result = await context.Verbs.ToListAsync();

            return result.Select(mapper.Map<Verb>).ToList();
        }
    }
}
