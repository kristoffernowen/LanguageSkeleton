﻿using Application.Services.VerbTenses;
using Application.Test.Mock;
using Core.Contracts.Repos;
using Core.Contracts.Services.Verb;
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
    public void ShouldReturnAr()
    {
        var talk = _mockRepo.Object.GetVerb("9bd47607 - 3e7d - 4780 - b4c4 - 0cf03e9167ad");

        talk = _pastTenseService.PastTense(talk);

        Assert.Equal("pratade", talk.DisplayForm);
    }

    [Fact]
    public void ShouldReturnEr()
    {
        var read = _mockRepo.Object.GetVerb("8de87010 - 3a43 - 4a4e - 9361 - b15ee46bc62f");

        read = _pastTenseService.PastTense(read);

        Assert.Equal("läste", read.DisplayForm);
    }

    [Fact]
    public void ShouldReturnStem()
    {
        var drive = _mockRepo.Object.GetVerb("f30412a7 - 2a41 - 42f5 - 8194 - 831d5183043e");

        drive = _pastTenseService.PastTense(drive);

        Assert.Equal("körde", drive.DisplayForm);
    }

    [Fact]
    public void ShouldReturnR()
    {
        var live = _mockRepo.Object.GetVerb("b86e5e92 - 960c - 42bf - bda8 - 9339529dd951");

        live = _pastTenseService.PastTense(live);

        Assert.Equal("bodde", live.DisplayForm);
    }
}