using Application.Contracts.Repos;
using Application.Contracts.Services.Noun;

namespace Application.Services.NounForms
{
    public class NounManager : INounManager
    {
        private readonly Lazy<INounService> _nounService;
        private readonly Lazy<IDefinitenessService> _definitenessService;

        public NounManager(INounRepo nounRepo)
        {
            _nounService = new Lazy<INounService>(() => new NounService(nounRepo));
            _definitenessService = new Lazy<IDefinitenessService>(() => new DefinitenessService());
        }

        public INounService NounService => _nounService.Value;
        public IDefinitenessService DefinitenessService => _definitenessService.Value;
    }
}
