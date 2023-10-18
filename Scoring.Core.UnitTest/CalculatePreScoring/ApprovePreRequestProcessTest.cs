using Moq;
using NUnit.Framework;
using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Core.Services.CalculatePreScoring;
using Scoring.Model.Entities;
using System.Collections.Generic;

namespace Scoring.Core.UnitTest.CalculatePreScoring
{
    public class ApprovePreRequestProcessTest
    {
        IApprovePreRequestProcess sut;
        List<IApproveRule> approveRules;
        Mock<IApproveRule> rule1;
        Mock<IApproveRule> rule2;
        Solicitud solicitud;

        [SetUp]
        public void Setup()
        {
            this.approveRules = new List<IApproveRule>();
            this.rule1 = new Mock<IApproveRule>();
            this.rule2 = new Mock<IApproveRule>();
            approveRules.Add(rule1.Object);
            approveRules.Add(rule2.Object);
            this.rule1.Setup(r => r.Check(It.IsAny<Solicitud>())).Returns(true);
            this.rule2.Setup(r => r.Check(It.IsAny<Solicitud>())).Returns(true);

            this.sut = new ApprovePreRequestProcess(approveRules);
            this.solicitud = new Solicitud();
        }

        [Test]
        public void ShouldBeTrue_When_AllApprovedRulesTrue()
        {
            //Given

            //When
            bool result = this.sut.ApproveAllRules(this.solicitud);
            //Then
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldBeFalse_When_FirstRuleIsFalse()
        {
            //Given
            this.rule1.Setup(r => r.Check(It.IsAny<Solicitud>())).Returns(false);
            //When
            bool result = this.sut.ApproveAllRules(this.solicitud);
            //Then
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldBeFalse_When_SecondRuleIsFalse()
        {
            //Given
            this.rule2.Setup(r => r.Check(It.IsAny<Solicitud>())).Returns(false);
            //When
            bool result = this.sut.ApproveAllRules(this.solicitud);
            //Then
            Assert.IsFalse(result);
        }
    }
}
