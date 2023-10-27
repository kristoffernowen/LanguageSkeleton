using Core.Models.Words;

namespace Core.Contracts.Services.Noun;

public interface INounFormService
{
    Models.Words.Noun SingularDefinitive(Models.Words.Noun noun);
}