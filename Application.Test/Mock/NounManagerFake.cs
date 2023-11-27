using Application.Contracts.Services.Noun;
using Domain.Models.Words;

namespace Application.Test.Mock
{
    public class NounManagerFake : INounManager
    {
        private readonly IDefiniteness _definiteness;
        private readonly IGrammaticalNumber _grammaticalNumber;

        public NounManagerFake(IDefiniteness definiteness, IGrammaticalNumber grammaticalNumber)
        {
            _definiteness = definiteness;
            _grammaticalNumber = grammaticalNumber;
        }
        
        public Noun SetDisplayForm(Noun noun)
        {
            noun = _grammaticalNumber.SetDisplayForm(noun);
            noun = _definiteness.SetDisplayForm(noun);

            return noun;
        }
    }
}
