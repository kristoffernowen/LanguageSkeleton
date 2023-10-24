﻿using Application.Services.VerbTenses;
using Core.Contracts.Services;
using Core.Enums;
using Core.Models.Words;

namespace Application.Test.VerbTenseServiceTests
{
    public class PresentTenseTests
    {
        private readonly IPresentTenseService _presentTenseService = new PresentTenseService();

        [Fact]
        public void ShouldReturnAr()
        {
            Verb talk = new()
            {
                BaseForm = "prata",
                Id = Guid.NewGuid().ToString(),
                VerbConjugation = VerbConjugation.ArVerb
            };

            talk = _presentTenseService.PresentTense(talk);

            Assert.Equal("pratar", talk.DisplayForm);
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

            read = _presentTenseService.PresentTense(read);

            Assert.Equal("läser", read.DisplayForm);
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

            drive = _presentTenseService.PresentTense(drive);

            Assert.Equal("kör", drive.DisplayForm);
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

            live = _presentTenseService.PresentTense(live);

            Assert.Equal("bor", live.DisplayForm);
        }
    }
}
