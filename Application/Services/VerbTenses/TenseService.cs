using Core.Models.Words;

namespace Application.Services.VerbTenses
{
    public class TenseService
    {
        protected string InfinitiveWithoutA(Verb verb)
        {
            return verb.Infinitive.Remove(verb.Infinitive.Length - 1, 1);
        }
    }
}
