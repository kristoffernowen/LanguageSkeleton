using Application.Contracts.Repos;
using AutoMapper;
using Data.PersistenceEntities;
using Domain.Models.Words;
using Microsoft.EntityFrameworkCore;

namespace Data.Repos
{
    public class VerbRepo : IVerbRepo
    {
        private readonly SqlContext _sqlContext;
        private readonly IMapper _mapper;

        public VerbRepo(SqlContext sqlContext, IMapper mapper)
        {
            _sqlContext = sqlContext;
            _mapper = mapper;
        }
        public async Task CreateVerbAsync(Verb verb)
        {
            verb.Id = Guid.NewGuid().ToString();

            await _sqlContext.AddAsync(_mapper.Map<VerbEntity>(verb));
            await _sqlContext.SaveChangesAsync();
        }

        public async Task<Verb> GetVerbAsync(string id)
        {
            var verb = await _sqlContext.Verbs.FirstOrDefaultAsync(x => x.Id == id) ?? throw new InvalidOperationException();

            return _mapper.Map<Verb>(verb);
        }

        public async Task<List<Verb>> GetAllVerbAsync()
        {
            return await _sqlContext.Verbs.Select(v => _mapper.Map<Verb>(v)).ToListAsync();
        }
    }
}
