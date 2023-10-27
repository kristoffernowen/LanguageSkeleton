using Application.Services.VerbTenses;
using Core.Contracts.Services.Verb;
using Core.Enums;
using Core.Models.Words;

namespace Application.Test.VerbTenseServiceTests;

public class PastTenseServiceTests
{
    private readonly IPastTenseService _pastTenseService = new PastTenseService();

    [Fact]
    public void ShouldReturnAr()
    {
        Verb talk = new()
        {
            BaseForm = "prata",
            Id = Guid.NewGuid().ToString(),
            VerbConjugation = VerbConjugation.ArVerb
        };

        talk = _pastTenseService.PastTense(talk);

        Assert.Equal("pratade", talk.DisplayForm);
    }

    [Fact]
    public void ShouldReturnEr()
    {
        Verb read = new()
        {
            BaseForm = "läsa",
            Id = Guid.NewGuid().ToString(),
            VerbConjugation = VerbConjugation.ErVerb
        };

        read = _pastTenseService.PastTense(read);

        Assert.Equal("läste", read.DisplayForm);
    }

    [Fact]
    public void ShouldReturnStem()
    {
        Verb drive = new()
        {
            BaseForm = "köra",
            Id = Guid.NewGuid().ToString(),
            VerbConjugation = VerbConjugation.ErVerb
        };

        drive = _pastTenseService.PastTense(drive);

        Assert.Equal("körde", drive.DisplayForm);
    }

    [Fact]
    public void ShouldReturnR()
    {
        Verb live = new()
        {
            BaseForm = "bo",
            Id = Guid.NewGuid().ToString(),
            VerbConjugation = VerbConjugation.RVerb
        };

        live = _pastTenseService.PastTense(live);

        Assert.Equal("bodde", live.DisplayForm);
    }
}