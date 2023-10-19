using Moq;
using NUnit.Framework;
using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoring.Core.Services.CalculatePreScoring;
using Scoring.Model.Entities;

namespace Scoring.Core.UnitTest.CalculatePreScoring
{
    public class CheckInversionIngresosNetosTest
    {
        private IApprovingRule service;
        private Solicitud solicitud;


        [OneTimeSetUp]
        public void SetupOnce()
        {
           
        }


        [SetUp]
        public void Setup()
        {
            service = new CheckInversionIngresosNetos();

        }

        [Test]
        public void Test_CheckInversionIngresosNetos_ShouldBeTrue_When_CheckTrue()
        {
            //Given
            solicitud = new Solicitud();
            solicitud.cliente = new Cliente();
            solicitud.Inversion = 5000.00;
            solicitud.cliente.IngresosNetosAnualesAutonomo = 3000.00;
            solicitud.cliente.IngresosNetosAnualesAsalariado = 2000.00;
            //When
            bool result = this.service.Check(solicitud);
            //Then
            Assert.IsTrue(result);
        }

        [Test]
        public void Test_CheckInversionIngresosNetos_ShouldBeFalse_When_CheckFalse()
        {
            //Given
            solicitud = new Solicitud();
            solicitud.cliente = new Cliente();
            solicitud.Inversion = 5000.00;
            solicitud.cliente.IngresosNetosAnualesAutonomo = 2000.00;
            solicitud.cliente.IngresosNetosAnualesAsalariado = 2000.00;
            //When
            bool result = this.service.Check(solicitud);
            //Then
            Assert.IsFalse(result);
        }

    }
}
