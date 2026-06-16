using System.ComponentModel;
using Domain.Enums.Noun;
using Domain.Models.ValueObjects;

namespace Application.Dtos.Sentence.Output;

public static class CreateSentenceNounOutputDtoExtensions
{
    public static CreateSentenceNounOutputDto ToSentenceNounOutputDto(this Noun model)
    {
        return new ()
        {
            Id = model.Id,
            DisplayForm = model.DisplayForm
        };
    }
}