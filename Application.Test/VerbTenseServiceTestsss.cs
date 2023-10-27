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
            BaseForm = "läsa",
            Id = Guid.NewGuid().ToString(),
            VerbConjugation = VerbConjugation.ErVerb
        };

        private Verb _drive = new()
        {
            BaseForm = "köra",
            Id = Guid.NewGuid().ToString(),
            VerbConjugation = VerbConjugation.ErVerb
        };

        private Verb _hanging = new()
        {
            BaseForm = "hänga",
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
            Assert.Equal("läste", _read.DisplayForm);
            Assert.Equal("körde", _drive.DisplayForm);
            Assert.Equal("hängde", _hanging.DisplayForm);
        }

    }
}