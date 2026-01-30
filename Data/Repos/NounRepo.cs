using Application.Contracts.Repos;
using AutoMapper;
using Data.PersistenceEntities;
using Domain.Models.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Repos
{
    public class NounRepo(
        SqlContext context, 
        IMapper mapper, 
        ILogger<NounRepo> logger)
        : INounRepo
    {
        private readonly ILogger<NounRepo> _logger = logger;

        public async Task CreateNounAsync(Noun noun)
        {
            noun.Id = Guid.NewGuid().ToString();

            context.Nouns.Add(mapper.Map<NounEntity>(noun));
            await context.SaveChangesAsync();
            
        }

        public async Task<Noun> GetNounAsync(string id)
        {
            var nounEntity = await context.Nouns.FirstOrDefaultAsync(x => x.Id == id);

            return mapper.Map<Noun>(nounEntity);
        }

        public async Task<List<Noun>> GetAllNounsAsync()
        {
            return await context.Nouns.Select(n => mapper.Map<Noun>(n)).ToListAsync();
        }
    }
}
