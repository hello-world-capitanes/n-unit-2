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
        

        [SetUp]
        public void Setup()
        {
            this.service = new CheckInversionTotal();
        }

        [Test]
        public void Test_CheckInversionTotal_ShouldBeTrue_When_CheckInversionTotal_Is_Lower()
        {
            //Given
            Solicitud solicitud = new Solicitud();
            solicitud.Inversion = 60000;
            //When
            bool result = service.Check(solicitud);
            //Then
            Assert.IsTrue(result);
        }
        [Test]
        public void Test_CheckInversionTotal_ShouldBeFalse_When_CheckInversionTotal_Is_Higher()
        {
            //Given
            Solicitud solicitud = new Solicitud();
            solicitud.Inversion = 90000;
            //When
            bool result = service.Check(solicitud);
            //Then
            Assert.IsFalse(result);
        }
    }
}
