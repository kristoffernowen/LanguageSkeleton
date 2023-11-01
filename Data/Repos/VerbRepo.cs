using AutoMapper;
using Data.PersistenceEntities;
using Domain.Contracts.Repos;
using Domain.Models.Words;

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
        public void CreateVerb(Verb verb)
        {
            verb.Id = Guid.NewGuid().ToString();

            _sqlContext.Add(_mapper.Map<VerbEntity>(verb));
            _sqlContext.SaveChanges();
        }

        public Verb GetVerb(string id)
        {
            var verb = _sqlContext.Verbs.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException();

            return _mapper.Map<Verb>(verb);
        }

        public List<Verb> GetAllVerb()
        {
            return _sqlContext.Verbs.Select(v => _mapper.Map<Verb>(v)).ToList();
        }
    }
}
