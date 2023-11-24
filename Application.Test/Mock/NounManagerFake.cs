using Application.Contracts.Services.Noun;
using Application.Services.NounForms;

namespace Application.Test.Mock
{
    public class NounManagerFake : INounManager
    {
        public IGrammaticalNumberService GrammaticalNumber => new GrammaticalNumberService();
        public IDefinitenessService DefinitenessService => new DefinitenessService();
    }
}
