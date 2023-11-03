namespace Application.Contracts.Services.Verb
{
    public interface IPresentTenseService
    {
        public Domain.Models.Words.Verb PresentTense(Domain.Models.Words.Verb verb);
    }
}
