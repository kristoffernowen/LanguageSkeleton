using Application.Services;
using Core.Contracts.Services.Verb;
using Core.Enums;
using Core.Models.Words;



namespace Application.Test
{
    public class VerbTenseServiceTestsss
    {
        private readonly IVerbTenseService _verbTenseService = new VerbTenseService();

        private Verb _talk = new()
        {
            BaseForm = "prata",
            Id = Guid.NewGuid().ToString(),
            VerbConjugation = VerbConjugation.ArVerb
        };

        private Verb _read = new()
        {
            BaseForm = "l�sa",
            Id = Guid.NewGuid().ToString(),
            VerbConjugation = VerbConjugation.ErVerb
        };

        private Verb _drive = new()
        {
            BaseForm = "k�ra",
            Id = Guid.NewGuid().ToString(),
            VerbConjugation = VerbConjugation.ErVerb
        };

        private Verb _hanging = new()
        {
            BaseForm = "h�nga",
            Id = Guid.NewGuid().ToString(),
            VerbConjugation = VerbConjugation.ErVerb
        };

        

        [Fact]
        public void ShouldReturnPastTense()
        {
            _drive = _verbTenseService.PastTense(_drive);
            _read = _verbTenseService.PastTense(_read);
            _hanging = _verbTenseService.PastTense(_hanging);
            _talk = _verbTenseService.PastTense(_talk);

            Assert.Equal("pratade", _talk.DisplayForm);
            Assert.Equal("l�ste", _read.DisplayForm);
            Assert.Equal("k�rde", _drive.DisplayForm);
            Assert.Equal("h�ngde", _hanging.DisplayForm);
        }

    }
}