using Application.Services.NounForms;

namespace Application.Contracts.Services.Noun
{
    public interface INounManager
    {
        public Domain.Models.Words.Noun SetDisplayForm(Domain.Models.Words.Noun noun);
    }
}
