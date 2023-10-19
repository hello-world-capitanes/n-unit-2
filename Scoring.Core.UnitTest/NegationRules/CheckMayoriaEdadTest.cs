using Scoring.Core.Interfaces.CalculatePreScoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoring.Model.Entities;
using NUnit.Framework;
using Scoring.Core.Services.CalculatePreScoring;
using Scoring.Core.Services.NegationRules;

namespace Scoring.Core.UnitTest.NegationRules
{
    internal class CheckMayoriaEdadTest
    {
        private INegationRule service;
        private Solicitud solicitud;



        [OneTimeSetUp]
        public void SetupOnce()
        {

        }


        [SetUp]
        public void Setup()
        {
            service = new CheckMayoriaEdad();
        }


        [Test]
        public void Test_CheckMayoriaEdad_ShouldBeTrue_When_AgeLessThan18()
        {

            //Given
            solicitud = new Solicitud();
            solicitud.cliente = new Cliente();
            solicitud.cliente.FechaDeNacimiento = new DateTime(year: 2006, month: 01, day: 01);
            //When
            bool result = service.Check(solicitud);
            //Then
            Assert.IsTrue(result);

        }

        [Test]
        public void Test_CheckMayoriaEdad_ShouldBeFalse_When_AgeMoreThan18()
        {

            //Given
            solicitud = new Solicitud();
            solicitud.cliente = new Cliente();
            solicitud.cliente.FechaDeNacimiento = new DateTime(year: 1990, month: 01, day: 01);
            //When
            bool result = service.Check(solicitud);
            //Then
            Assert.IsFalse(result);

        }



    }
}
