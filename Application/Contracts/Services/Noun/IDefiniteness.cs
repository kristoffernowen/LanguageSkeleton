namespace Application.Contracts.Services.Noun;

public interface IDefiniteness
{
    public Domain.Models.Words.Noun Definite(Domain.Models.Words.Noun noun);
    public Domain.Models.Words.Noun Indefinite(Domain.Models.Words.Noun noun);
    public Domain.Models.Words.Noun SetDisplayForm(Domain.Models.Words.Noun noun);
}