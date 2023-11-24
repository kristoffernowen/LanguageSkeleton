using Application.Contracts.Services.Verb;
using Application.Services.VerbTenses;

namespace Application.Test.Mock
{
    public class VerbManagerFake : ITenseManager
    {
        private readonly Lazy<IPresentTenseService> _presentTenseService;
        private readonly Lazy<IPastTenseService> _pastTenseService;
        private readonly Lazy<IPerfectTenseService> _perfectTenseService;
        private readonly Lazy<IFutureTenseService> _futureTenseService;

        public VerbManagerFake()
        {
            _presentTenseService = new Lazy<IPresentTenseService>(() => new PresentTenseService());
            _pastTenseService = new Lazy<IPastTenseService>(() => new PastTenseService());
            _perfectTenseService = new Lazy<IPerfectTenseService>(() => new PerfectTenseService());
            _futureTenseService = new Lazy<IFutureTenseService>(() => new FutureTenseService());
        }

        public IPresentTenseService PresentTenseService => _presentTenseService.Value;
        public IPastTenseService PastTenseService => _pastTenseService.Value;
        public IPerfectTenseService PerfectTenseService => _perfectTenseService.Value;
        public IFutureTenseService FutureTenseService => _futureTenseService.Value;
    }
}
