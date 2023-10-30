using AutoMapper;
using Core.Contracts.Repos;
using Core.Models.Words;
using Data.PersistenceEntities;

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
        public void CreateNoun(Noun noun)
        {
            noun.Id = Guid.NewGuid().ToString();

            _sqlContext.Nouns.Add(_mapper.Map<NounEntity>(noun));
            _sqlContext.SaveChanges();
        }

        public Noun GetNoun(string id)
        {
            throw new NotImplementedException();
        }

        public List<Noun> GetAllNouns()
        {
            return _sqlContext.Nouns.Select(n => _mapper.Map<Noun>(n)).ToList();
        }
    }
}
