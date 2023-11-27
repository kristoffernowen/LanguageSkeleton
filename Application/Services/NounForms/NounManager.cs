using Application.Contracts.Services.Noun;
using Domain.Models.Words;

namespace Application.Services.NounForms
{
    public class NounManager : INounManager
    {
        private readonly IGrammaticalNumber _grammaticalNumber;
        private readonly IDefiniteness _definiteness;

        public NounManager(IGrammaticalNumber grammaticalNumber, IDefiniteness definiteness)
        {
            _grammaticalNumber = grammaticalNumber;
            _definiteness = definiteness;
        }

        public Noun SetDisplayForm(Noun noun)
        {
            noun =  _grammaticalNumber.SetDisplayForm(noun);
            noun = _definiteness.SetDisplayForm(noun);

            return noun;
        }
    }
}
