using MediatR;

namespace Application.Features.Nouns.Commands
{
    public record CreateNounCommand(string SingularForm, string PluralForm, int NounDeclension, string NounArticle) : IRequest<Unit>;
    // public string SingularForm { get; set; } = null!;
    // public string PluralForm { get; set; } = null!;
    // public int NounDeclension { get; set; }
    // public string NounArticle { get; set; } = null!;
}
