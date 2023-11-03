namespace Application.Contracts.Services.Noun
{
    public interface IGrammaticalNumberService
    {
        public Domain.Models.Words.Noun Singular(Domain.Models.Words.Noun noun);
        public Domain.Models.Words.Noun Plural(Domain.Models.Words.Noun noun);
    }
}
