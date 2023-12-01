using Application.Contracts.Repos;
using AutoMapper;
using Data.PersistenceEntities;
using Data.PersistenceEntities.Extensions;
using Domain.Models.Words;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Repos
{
    public class NounRepo : INounRepo
    {
        private readonly SqlContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<NounRepo> _logger;

        public NounRepo(SqlContext context, IMapper mapper, ILogger<NounRepo> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task CreateNounAsync(Noun noun)
        {
            noun.Id = Guid.NewGuid().ToString();

            _context.Nouns.Add(_mapper.Map<NounEntity>(noun));
            await _context.SaveChangesAsync();
            
        }

        public async Task<Noun> GetNounAsync(string id)
        {
            var nounEntity = await _context.Nouns.FirstOrDefaultAsync(x => x.Id == id);

            // return _mapper.Map<Noun>(nounEntity);
            return nounEntity.ToModel();
        }

        public async Task<List<Noun>> GetAllNounsAsync()
        {
            return await _context.Nouns.Select(n => _mapper.Map<Noun>(n)).ToListAsync();
        }
    }
}
