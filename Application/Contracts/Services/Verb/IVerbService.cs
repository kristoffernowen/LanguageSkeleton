namespace Application.Contracts.Services.Verb
{
    public interface IVerbService
    {
        public Task CreateVerbAsync(Domain.Models.Words.Verb verb);
        public Task<List<Domain.Models.Words.Verb>> GetAllAsync();
        public Task<Domain.Models.Words.Verb> GetAsync(string id);
        public Task<Domain.Models.Words.Verb> GetByPresentTense(string presentTense);
    }
}
