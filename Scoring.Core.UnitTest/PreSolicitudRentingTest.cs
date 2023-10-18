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

        [OneTimeSetUp]
        public void SetupOnce()
        {

        }

        [SetUp]
        public void Setup()
        {
            this.service = new PreSolicitudRenting(this.approvePreRequestProcessMock.Object);
        }

        [Test]
        public void Test_CalculatePreRequest_ShouldBeTrue_When_ApprovedRulesTrue()
        {
            //Given
            this.approvePreRequestProcessMock.Setup(a => a.ApprovedRules()).Returns(true);
            //When
            bool result = this.service.CalculatePreRequest();
            //Then
            Assert.IsTrue(result);
        }

        [Test]
        public void Test_CalculatePreRequest_ShouldBeFalse_When_ApprovedRulesFalse()
        {
            //Given
            this.approvePreRequestProcessMock.Setup(a => a.ApprovedRules()).Returns(false);
            //When
            bool result = this.service.CalculatePreRequest();
            //Then
            Assert.IsFalse(result);
        }
    }
}