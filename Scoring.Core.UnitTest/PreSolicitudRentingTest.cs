using Moq;
using NUnit.Framework;
using Scoring.Core.Interfaces;
using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Core.Services;
using Scoring.Model;
using Scoring.Model.Entities;

namespace Scoring.Core.UnitTest
{
    public class PreSolicitudRentingTest
    {
        private IPreSolicitudRenting service;
        private Mock<IApprovePreRequestProcess> approvePreRequestProcessMock = new Mock<IApprovePreRequestProcess>();
        private Mock<IDenyPreRequestProcess> denyPreRequestProcessMock = new Mock<IDenyPreRequestProcess>();
        Solicitud solicitud;

       
        [SetUp]
        public void Setup()
        {
            this.service = new PreSolicitudRenting(this.approvePreRequestProcessMock.Object, this.denyPreRequestProcessMock.Object);
            solicitud = new Solicitud();
        }

        [Test]
        public void Test_CalculatePreRequest_ShouldBeAccepted_When_ApprovedRulesTrueAndNotDenyAny()
        {
            //Given
            this.approvePreRequestProcessMock.Setup(a => a.ApproveAllRules(It.IsAny<Solicitud>())).Returns(true);
            this.denyPreRequestProcessMock.Setup(a => a.DeniedAnyRule(It.IsAny<Solicitud>())).Returns(false);
            //When
            EstadoPreSolicitud result = this.service.CalculatePreRequest(solicitud);
            //Then
            Assert.AreEqual(EstadoPreSolicitud.PreAceptada, result);
        }

        [Test]
        public void Test_CalculatePreRequest_ShouldBeDenied_When_ApprovedRulesTrueAndAnyDenied()
        {
            //Given
            this.approvePreRequestProcessMock.Setup(a => a.ApproveAllRules(It.IsAny<Solicitud>())).Returns(true);
            this.denyPreRequestProcessMock.Setup(a => a.DeniedAnyRule(It.IsAny<Solicitud>())).Returns(true);
            //When
            EstadoPreSolicitud result = this.service.CalculatePreRequest(solicitud);
            //Then
            Assert.AreEqual(EstadoPreSolicitud.PreDenegeda, result);
        }

        [Test]
        public void Test_CalculatePreRequest_ShouldBeDenied_When_ApprovedRulesFalseAndAnyDenied()
        {
            //Given
            this.approvePreRequestProcessMock.Setup(a => a.ApproveAllRules(It.IsAny<Solicitud>())).Returns(false);
            this.denyPreRequestProcessMock.Setup(a => a.DeniedAnyRule(It.IsAny<Solicitud>())).Returns(true);
            //When
            EstadoPreSolicitud result = this.service.CalculatePreRequest(solicitud);
            //Then
            Assert.AreEqual(EstadoPreSolicitud.PreDenegeda, result);
        }

        [Test]
        public void Test_CalculatePreRequest_ShouldBeDueToAnalist_When_ApprovedRulesFalseAndNotDenied()
        {
            //Given
            this.approvePreRequestProcessMock.Setup(a => a.ApproveAllRules(It.IsAny<Solicitud>())).Returns(false);
            this.denyPreRequestProcessMock.Setup(a => a.DeniedAnyRule(It.IsAny<Solicitud>())).Returns(false);
            //When
            EstadoPreSolicitud result = this.service.CalculatePreRequest(solicitud);
            //Then
            Assert.AreEqual(EstadoPreSolicitud.PendienteAnalista, result);
        }
    }
}