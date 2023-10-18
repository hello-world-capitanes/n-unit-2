using Moq;
using NUnit.Framework;
using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Core.Services.CalculatePreScoring;
using Scoring.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.Core.UnitTest.CalculatePreScoring
{
    internal class CheckInversionTotalTest
    {
        private IApprovingRule service;
        private Mock<IApprovingRule> approvePreRequestProcessMock = new Mock<IApprovingRule>();
        private Solicitud solicitud;

        [SetUp]
        public void Setup()
        {
            this.service = new CheckInversionTotal();
        }

        [Test]
        public void Text_ChheckInversionTotal_ShouldBeTrue()
        {
            //Given
            this.approvePreRequestProcessMock.Setup(a => a.Check(solicitud));
            //When
            bool result = this.service.Check(solicitud);
            //Then
            Assert.IsTrue(result);
        }
        [Test]
        public void Text_ChheckInversionTotal_ShouldBeFalse()
        {
            //Given
            this.approvePreRequestProcessMock.Setup(a => a.Check(solicitud));
            //When
            bool result = this.service.Check(solicitud);
            //Then
            Assert.IsFalse(result);
        }
    }
}
