namespace Domain.Contracts.Services.Verb
{
    public interface IVerbService
    {
        public void CreateVerb(Models.Words.Verb verb);
        public List<Models.Words.Verb> GetAll();
        public Models.Words.Verb Get(string id);
    }
}
