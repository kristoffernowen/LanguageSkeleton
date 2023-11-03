using Application.Contracts.Repos;
using AutoMapper;
using Data.PersistenceEntities;
using Domain.Models.Words;
using Microsoft.EntityFrameworkCore;

namespace Data.Repos
{
    public class NounRepo : INounRepo
    {
        private readonly SqlContext _sqlContext;
        private readonly IMapper _mapper;

        public NounRepo(SqlContext sqlContext, IMapper mapper)
        {
            _sqlContext = sqlContext;
            _mapper = mapper;
        }
        public async Task CreateNounAsync(Noun noun)
        {
            noun.Id = Guid.NewGuid().ToString();

            await _sqlContext.Nouns.AddAsync(_mapper.Map<NounEntity>(noun));
            await _sqlContext.SaveChangesAsync();
        }

        public async Task<Noun> GetNounAsync(string id)
        {
            var nounEntity = await _sqlContext.Nouns.FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<Noun>(nounEntity);
        }

        public async Task<List<Noun>> GetAllNounsAsync()
        {
            return await _sqlContext.Nouns.Select(n => _mapper.Map<Noun>(n)).ToListAsync();
        }
    }
}
