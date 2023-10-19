using NUnit.Framework;
using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Core.Services.DenegateRules;
using Scoring.Model.Entities;
using System;

namespace Scoring.Core.UnitTest.NegationRules
{
    internal class CheckEdadPlazoTest
    {
        private INegationRule service;
        Solicitud solicitud;

        [SetUp]
        public void Setup()
        {
            service = new CheckEdadPlazo();
        }

        [Test]
        public void Test_CheckEdadPlazo_ShouldBeTrue_When_CheckEdadPlazo_Is_Higher()
        {
            //Given
            solicitud = new Solicitud();
            solicitud.cliente = new Cliente();
            solicitud.cliente.FechaDeNacimiento = DateTime.Parse("15/12/1950");
            solicitud.Plazo = 120;
            //When
            bool result = service.Check(solicitud);
            //Then
            Assert.IsTrue(result);
        }

        [Test]
        public void Test_CheckEdadPlazo_ShouldBeFalse_When_CheckEdadPlazo_Is_Lower()
        {
            //Given
            solicitud = new Solicitud();
            solicitud.cliente = new Cliente();
            solicitud.cliente.FechaDeNacimiento = new DateTime(1992, 12, 15);
            solicitud.Plazo = 120;
            //When
            bool result = service.Check(solicitud);
            //Then
            Assert.IsFalse(result);
        }

    }
}
