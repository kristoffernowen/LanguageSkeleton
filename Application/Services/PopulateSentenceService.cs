using Domain.Contracts.Services.Sentence;
using Domain.Models.Sentence;

namespace Application.Services
{
    public class PopulateSentenceService : IPopulateSentenceService
    {
        
        public Sentence CreateSentence(Sentence sentence)
        {
            // set form of words
            // arrange wordorder

            return sentence;
        }

        public Sentence AddObjectToSentence(Sentence sentence)
        {
            throw new NotImplementedException();
        }

        public Sentence RemoveObjectFromSentence(Sentence sentence)
        {
            throw new NotImplementedException();
        }
    }
}
