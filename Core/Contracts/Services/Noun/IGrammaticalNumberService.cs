namespace Domain.Contracts.Services.Noun
{
    public interface IGrammaticalNumberService
    {
        public Models.Words.Noun Singular(Models.Words.Noun noun);
        public Models.Words.Noun Plural(Models.Words.Noun noun);
    }
}
