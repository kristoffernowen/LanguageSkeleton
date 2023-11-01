namespace Domain.Contracts.Services.Noun;

public interface IDefinitenessService
{
    public Models.Words.Noun Definite(Models.Words.Noun noun);
    public Models.Words.Noun Indefinite(Models.Words.Noun noun);
}