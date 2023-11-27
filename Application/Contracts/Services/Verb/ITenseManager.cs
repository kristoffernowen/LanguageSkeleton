using Domain.Enums;

namespace Application.Contracts.Services.Verb
{
    public interface ITenseManager
    {
        public Domain.Models.Words.Verb SetDisplayForm(Tense tense, Domain.Models.Words.Verb verb);
    }
}
