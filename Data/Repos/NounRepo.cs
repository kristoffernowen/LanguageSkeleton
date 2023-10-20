using Core.Contracts.Repos;
using Core.Models.Words;

namespace Data.Repos
{
    public class NounRepo : INounRepo
    {
        private readonly SqlContext _sqlContext;

        public NounRepo(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }
        public void CreateNoun(Noun noun)
        {
            noun.Id = Guid.NewGuid().ToString();

            _sqlContext.Nouns.Add(noun);
            _sqlContext.SaveChanges();
        }

        public Noun GetNoun(string id)
        {
            throw new NotImplementedException();
        }

        public List<Noun> GetAllNouns()
        {
            return _sqlContext.Nouns.ToList();
        }
    }
}
