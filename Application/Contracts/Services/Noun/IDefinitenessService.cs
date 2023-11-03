namespace Application.Contracts.Services.Noun;

public interface IDefinitenessService
{
    public Domain.Models.Words.Noun Definite(Domain.Models.Words.Noun noun);
    public Domain.Models.Words.Noun Indefinite(Domain.Models.Words.Noun noun);
    public Domain.Models.Words.Noun SetDefinitenessDisplayForm(Domain.Models.Words.Noun noun);
}