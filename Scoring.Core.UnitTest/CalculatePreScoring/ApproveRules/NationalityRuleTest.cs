using NUnit.Framework;
using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Core.Services.CalculatePreScoring.ApproveRules;
using Scoring.Model.Entities;

namespace Scoring.Core.UnitTest.CalculatePreScoring.ApproveRules
{


    public class NationalityRuleTest
    {

        private IApproveRule rule;

        [SetUp]
        public void Setup()
        {
            this.rule = new NationalityRule();            
        }

        [Test]
        public void Test_ShouldBeTrue_When_NationalityIses()
        {
            //Given
            Solicitud solicitud = new Solicitud();
            solicitud.Cliente = new Cliente{
                Nacionalidad = "es"
            };

            //When
            bool result = this.rule.Check(solicitud);
            //Then
            Assert.IsTrue(result);
        }

        [Test]
        public void Test_ShouldBeTrue_When_NationalityIsES()
        {
            //Given
            Solicitud solicitud = new Solicitud();
            solicitud.Cliente = new Cliente {
                Nacionalidad = "ES"
            };

            //When
            bool result = this.rule.Check(solicitud);
            //Then
            Assert.IsTrue(result);
        }

        [Test]
        public void Test_ShouldBeFalse_When_NationalityIsPT()
        {
            //Given
            Solicitud solicitud = new Solicitud();
            solicitud.Cliente = new Cliente {
                Nacionalidad = "PT"
            };

            //When
            bool result = this.rule.Check(solicitud);
            //Then
            Assert.IsFalse(result);
        }

        [Test]
        public void Test_ShouldBeFalse_When_NationalityIsNull()
        {
            //Given
            Solicitud solicitud = new Solicitud();
            solicitud.Cliente = new Cliente ();

            //When
            bool result = this.rule.Check(solicitud);
            //Then
            Assert.IsFalse(result);
        }

    }
}
