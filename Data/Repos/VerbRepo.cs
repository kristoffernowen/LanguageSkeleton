using Core.Contracts.Repos;
using Core.Models.Words;

namespace Data.Repos
{
    public class VerbRepo : IVerbRepo
    {
        private readonly SqlContext _sqlContext;

        public VerbRepo(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }
        public void CreateVerb(Verb verb)
        {
            verb.Id = Guid.NewGuid().ToString();

            _sqlContext.Add(verb);
            _sqlContext.SaveChanges();
        }

        public Verb GetVerb(string id)
        {
            throw new NotImplementedException();
        }

        public List<Verb> GetAllVerb()
        {
            return _sqlContext.Verbs.ToList();
        }
    }
}
