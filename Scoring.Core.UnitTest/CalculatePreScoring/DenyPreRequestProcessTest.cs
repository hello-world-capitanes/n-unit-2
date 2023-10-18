using Moq;
using NUnit.Framework;
using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Core.Services.CalculatePreScoring;
using Scoring.Model.Entities;
using System.Collections.Generic;

namespace Scoring.Core.UnitTest.CalculatePreScoring
{
    public class DenyPreRequestProcessTest
    {
        IDenyPreRequestProcess sut;
        List<IDenyRule> denyRules;
        Mock<IDenyRule> rule1;
        Mock<IDenyRule> rule2;
        Solicitud solicitud;

        [SetUp]
        public void Setup()
        {
            this.denyRules = new List<IDenyRule>();
            this.rule1 = new Mock<IDenyRule>();
            this.rule2 = new Mock<IDenyRule>();
            denyRules.Add(rule1.Object);
            denyRules.Add(rule2.Object);
            this.rule1.Setup(r => r.Check(It.IsAny<Solicitud>())).Returns(false);
            this.rule2.Setup(r => r.Check(It.IsAny<Solicitud>())).Returns(false);

            this.sut = new DenyPreRequestProcess(denyRules);
            this.solicitud = new Solicitud();
        }

        [Test]
        public void ShouldBeFalse_When_AllApprovedRulesFalse()
        {
            //Given

            //When
            bool result = this.sut.DeniedAnyRule(this.solicitud);
            //Then
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldBeTrue_When_FirstRuleIsTrue()
        {
            //Given
            this.rule1.Setup(r => r.Check(It.IsAny<Solicitud>())).Returns(true);
            //When
            bool result = this.sut.DeniedAnyRule(this.solicitud);
            //Then
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldBeFalse_When_SecondRuleIsFalse()
        {
            //Given
            this.rule2.Setup(r => r.Check(It.IsAny<Solicitud>())).Returns(true);
            //When
            bool result = this.sut.DeniedAnyRule(this.solicitud);
            //Then
            Assert.IsTrue(result);
        }
    }
}
