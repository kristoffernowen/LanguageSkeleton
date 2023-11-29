using Domain.Models.Words;

namespace Domain.Models.Sentence;

public abstract class TenseBehavior
{
    public abstract Verb SetDisplayForm(Verb verb);
}