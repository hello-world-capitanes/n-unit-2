using Moq;
using NUnit.Framework;
using Scoring.Core.Interfaces;
using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Core.Services;

namespace Scoring.Core.UnitTest
{
    public class PreSolicitudRentingTest
    {
        private IPreSolicitudRenting service;
        private Mock<IApprovePreRequestProcess> approvePreRequestProcessMock = new Mock<IApprovePreRequestProcess>();
        [SetUp]
        public void Setup()
        {
            this.service = new PreSolicitudRenting(this.approvePreRequestProcessMock.Object);
        }

        [Test]
        public void Test_CalculatePreRequest_ShouldBeTrue_When_ApprovedRulesTrue()
        {
            this.approvePreRequestProcessMock.Setup(a => a.ApprovedRules()).Returns(true);
            Assert.IsTrue(this.service.CalculatePreRequest());            
        }

        [Test]
        public void Test_CalculatePreRequest_ShouldBeFalse_When_ApprovedRulesFalse()
        {
            this.approvePreRequestProcessMock.Setup(a => a.ApprovedRules()).Returns(false);
            Assert.IsFalse(this.service.CalculatePreRequest());
        }
    }
}