using Application.Dtos.Sentence.Input;
using Application.Dtos.Sentence.Output;

namespace Application.Contracts.Services.Sentence;

public interface IPopulateSentenceService
{
    Task<CreateSentenceOutputDto> CreateSentenceBaseAsync(CreateSentenceInputDto dto);
    Task<Domain.Models.Sentence.Sentence> AddObjectToSentence(Domain.Models.Sentence.Sentence sentence);
    Task<Domain.Models.Sentence.Sentence> RemoveObjectFromSentence(Domain.Models.Sentence.Sentence sentence);
}