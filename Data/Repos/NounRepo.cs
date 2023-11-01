using AutoMapper;
using Data.PersistenceEntities;
using Domain.Contracts.Repos;
using Domain.Models.Words;

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
            var nounEntity = _sqlContext.Nouns.FirstOrDefault(x => x.Id == id);

            return _mapper.Map<Noun>(nounEntity);
        }

        public List<Noun> GetAllNouns()
        {
            return _sqlContext.Nouns.Select(n => _mapper.Map<Noun>(n)).ToList();
        }
    }
}
