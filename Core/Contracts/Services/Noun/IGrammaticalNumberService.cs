namespace Core.Contracts.Services.Noun
{
    public interface IGrammaticalNumberService
    {
        public Models.Words.Noun Singular(Models.Words.Noun noun);
        public Models.Words.Noun Plural(Models.Words.Noun noun);
    }

    public interface IDefinitenessService
    {
        public Models.Words.Noun Definite(Models.Words.Noun noun);
        public Models.Words.Noun Indefinite(Models.Words.Noun noun);
    }
}
