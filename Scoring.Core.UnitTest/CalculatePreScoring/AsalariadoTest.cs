using Moq;
using NUnit.Framework;
using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Core.Services.CalculatePreScoring;
using Scoring.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.Core.UnitTest.CalculatePreScoring
{
    internal class AsalariadoTest
    {
        private IApprovingRule service;


        [SetUp]
        public void Setup()
        {
            this.service = new Asalariado();
        }

        [Test]
        public void Test_CheckAsalariado_ShouldBeFalse_When_CIF_Is_Different()
        {
            //Given
            Solicitud solicitud = new Solicitud();
            DateTime fecha = new DateTime(1982, 12, 31);
            solicitud.cliente = new Cliente();
            string CIFprueba = "2457804";
            solicitud.cliente.CifEmpleador = CIFprueba;
            solicitud.cliente.FechaInicioAsalariado = fecha;
            //When
            bool result = this.service.Check(solicitud);
            //Then
            Assert.IsFalse(result);
        }

        [Test]
        public void Test_CheckAsalariado_ShouldBeTrue_When_CIF_Is_The_Same()
        {
            //Given
            Solicitud solicitud = new Solicitud();
            DateTime fecha = new DateTime(1982, 12, 31);
            solicitud.cliente = new Cliente();
            string CIFprueba = "2457802";
            solicitud.cliente.CifEmpleador = CIFprueba;
            solicitud.cliente.FechaInicioAsalariado = fecha;
            //When
            bool result = this.service.Check(solicitud);
            //Then
            Assert.IsTrue(result);
        }

        [Test]
        public void Test_CheckAsalariado_ShouldBeFalse_When_DataTime_Is_Higher()
        {
            //Given
            Solicitud solicitud = new Solicitud();
            DateTime fecha = new DateTime(2050, 12, 31); //Deberia devolver 1
            solicitud.cliente = new Cliente();
            solicitud.cliente.FechaInicioAsalariado = fecha;
            string CIFprueba = "2457802";
            solicitud.cliente.CifEmpleador = CIFprueba;
            //When
            bool result = this.service.Check(solicitud);
            //Then
            Assert.IsFalse(result);
        }

    }
}
