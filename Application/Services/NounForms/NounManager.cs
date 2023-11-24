using Application.Contracts.Repos;
using Application.Contracts.Services.Noun;

namespace Application.Services.NounForms
{
    public class NounManager : INounManager
    {
        private readonly Lazy<IDefinitenessService> _definitenessService;
        private readonly Lazy<IGrammaticalNumberService> _grammaticalNumberService;

        public NounManager(INounRepo nounRepo)
        {
            _definitenessService = new Lazy<IDefinitenessService>(() => new DefinitenessService());
            _grammaticalNumberService = new Lazy<IGrammaticalNumberService>(() => new GrammaticalNumberService());
        }

        public IGrammaticalNumberService GrammaticalNumber => _grammaticalNumberService.Value;
        public IDefinitenessService DefinitenessService => _definitenessService.Value;
    }
}
