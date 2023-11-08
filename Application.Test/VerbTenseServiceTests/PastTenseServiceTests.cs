using Application.Contracts.Repos;
using Application.Contracts.Services.Verb;
using Application.Services.VerbTenses;
using Application.Test.Mock;
using Moq;

namespace Application.Test.VerbTenseServiceTests;

public class PastTenseServiceTests
{
    private readonly Mock<IVerbRepo> _mockRepo;
    private readonly IPastTenseService _pastTenseService = new PastTenseService();

    public PastTenseServiceTests()
    {
        _mockRepo = MockVerbRepo.GetVerbMockVerbRepo();
    }

    [Fact]
    public async void ShouldReturnAr()
    {
        var talk = await _mockRepo.Object.GetVerbAsync("9bd47607 - 3e7d - 4780 - b4c4 - 0cf03e9167ad");

        talk = _pastTenseService.SetDisplayForm(talk);

        Assert.Equal("pratade", talk.DisplayForm);
    }

    [Fact]
    public async void ShouldReturnEr()
    {
        var read = await _mockRepo.Object.GetVerbAsync("8de87010 - 3a43 - 4a4e - 9361 - b15ee46bc62f");

        read = _pastTenseService.SetDisplayForm(read);

        Assert.Equal("läste", read.DisplayForm);
    }

    [Fact]
    public async void ShouldReturnStem()
    {
        var drive = await _mockRepo.Object.GetVerbAsync("f30412a7 - 2a41 - 42f5 - 8194 - 831d5183043e");

        drive = _pastTenseService.SetDisplayForm(drive);

        Assert.Equal("körde", drive.DisplayForm);
    }

    [Fact]
    public async void ShouldReturnR()
    {
        var live = await _mockRepo.Object.GetVerbAsync("b86e5e92 - 960c - 42bf - bda8 - 9339529dd951");

        live = _pastTenseService.SetDisplayForm(live);

        Assert.Equal("bodde", live.DisplayForm);
    }
}