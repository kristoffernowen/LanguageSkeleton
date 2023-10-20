using Core.Models.Words;

namespace Core.Contracts.Services;

public interface INounFormService
{
    Noun SingularDefinitive(Noun noun);
}