namespace Application.Contracts.Services.Verb
{
    public interface ITenseManager
    {
        IPresentTenseService PresentTenseService { get; }
        IPastTenseService PastTenseService { get; }
        IPerfectTenseService PerfectTenseService { get; }
        IFutureTenseService FutureTenseService { get; }
    }
}
