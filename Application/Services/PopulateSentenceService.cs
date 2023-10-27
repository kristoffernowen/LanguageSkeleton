using Core.Contracts.Services.Sentence;
using Core.Models.Sentence;

namespace Application.Services
{
    public class PopulateSentenceService : IPopulateSentenceService
    {
        // private readonly IVerbRepo _verbRepo;
        // private readonly INounRepo _nounRepo;
        //
        // public PopulateSentenceService(IVerbRepo verbRepo, INounRepo nounRepo)
        // {
        //     _verbRepo = verbRepo;
        //     _nounRepo = nounRepo;
        // }
        public Sentence CreateSentence(Sentence sentence)
        {
            // no, the sentence will be created UI as a dto that populates a sentence. This sentence will
            // be manipulated. The dto must contain instructions what should be done. Controller will
            // call appropriate services and return dto based on display form.

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
