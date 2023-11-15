using Application.Contracts.Repos;
using AutoMapper;
using Data.PersistenceEntities.Verbs;
using Domain.Enums;
using Domain.Models.Words;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Repos
{
    public class VersionVerbRepo : IVerbRepo
    {
        private readonly SqlContext _context;
        private readonly IMapper _mapper;

        public VersionVerbRepo(SqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task CreateVerbAsync(Verb verb)
        {
            verb.Id = Guid.NewGuid().ToString();
            
                switch (verb.VerbConjugation)
                {
                    case VerbConjugation.ArVerb or VerbConjugation.ErVerb:
                        _context.BaseVerbs.Add(_mapper.Map<WeakVerb>(verb));
                        await _context.SaveChangesAsync();
                        break;
                    case VerbConjugation.RVerb:
                        _context.BaseVerbs.Add(_mapper.Map<ShortVerb>(verb));
                        await _context.SaveChangesAsync();
                        break;
                    case VerbConjugation.StrongErVerb:
                        _context.BaseVerbs.Add(_mapper.Map<StrongVerb>(verb));
                        await _context.SaveChangesAsync();
                        break;
                    case VerbConjugation.IrregularVerb:
                        _context.BaseVerbs.Add(_mapper.Map<IrregularVerb>(verb));
                        await _context.SaveChangesAsync();
                        break;
                }
        }

        public async Task<Verb> GetVerbAsync(string id)
        {
            var result = await _context.BaseVerbs.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<Verb>(result);
        }

        public async Task<Verb> GetVerbFromPresentTenseAsync(string presentTense)
        {
            var result = await _context.BaseVerbs.FirstOrDefaultAsync(v=> v.PresentTense == presentTense);

            return _mapper.Map<Verb>(result);
        }


        public async Task<List<Verb>> GetAllVerbAsync()
        {
            var result = await _context.BaseVerbs.ToListAsync();

            return result.Select(v => _mapper.Map<Verb>(v)).ToList();
        }
    }
}
