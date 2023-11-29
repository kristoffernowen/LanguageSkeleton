using Application.Contracts.Services.Verb;
using Domain.Models.Sentence;
using Domain.Models.Words;

namespace Application.Services.VerbTenses
{
    public class PresentTense : TenseBehavior
    {
        public override Verb SetDisplayForm(Verb verb)
        {
            verb.DisplayForm = verb.PresentTense;

            return verb;
        }
    }
}
