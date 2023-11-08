using Application.Contracts.Repos;
using Application.Contracts.Services.Verb;
using Application.Services.VerbTenses;
using Application.Test.Mock;
using Moq;

namespace Application.Test.VerbTenseServiceTests
{
    public class PresentTenseTests
    {
        private readonly IPresentTenseService _presentTenseService = new PresentTenseService();
        private readonly Mock<IVerbRepo> _mockRepo;

        public PresentTenseTests()
        {
            _mockRepo = MockVerbRepo.GetVerbMockVerbRepo();
        }

        [Fact]
        public async void ShouldReturnAr()
        {
            var talk = await _mockRepo.Object.GetVerbAsync("9bd47607 - 3e7d - 4780 - b4c4 - 0cf03e9167ad");

            talk = _presentTenseService.SetDisplayForm(talk);

            Assert.Equal("pratar", talk.DisplayForm);
        }

        [Fact]
        public async void ShouldReturnEr()
        {
            var read = await _mockRepo.Object.GetVerbAsync("8de87010 - 3a43 - 4a4e - 9361 - b15ee46bc62f");

            read = _presentTenseService.SetDisplayForm(read);

            Assert.Equal("läser", read.DisplayForm);
        }

        [Fact]
        public async void ShouldReturnStem()
        {
            var drive = await _mockRepo.Object.GetVerbAsync("f30412a7 - 2a41 - 42f5 - 8194 - 831d5183043e");

            drive = _presentTenseService.SetDisplayForm(drive);

            Assert.Equal("kör", drive.DisplayForm);
        }

        [Fact]
        public async void ShouldReturnR()
        {
            var live = await _mockRepo.Object.GetVerbAsync("b86e5e92 - 960c - 42bf - bda8 - 9339529dd951");

            live = _presentTenseService.SetDisplayForm(live);

            Assert.Equal("bor", live.DisplayForm);
        }
    }
}
