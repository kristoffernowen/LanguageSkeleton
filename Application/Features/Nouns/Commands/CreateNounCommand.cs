using MediatR;

namespace Application.Features.Nouns.Commands
{
    public record CreateNounCommand(string SingularForm, string PluralForm, string NounArticle, int NounDeclension, string GrammaticalGender) : IRequest<Unit>;
}
