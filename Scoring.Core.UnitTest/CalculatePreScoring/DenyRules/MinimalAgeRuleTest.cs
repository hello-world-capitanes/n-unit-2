

using NUnit.Framework;
using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Core.Services.CalculatePreScoring.DenyRules;
using Scoring.Model.Entities;
using System;

namespace Scoring.Core.UnitTest.CalculatePreScoring.DenyRules
{
    public class MinimalAgeRuleTest
    {
        private IDenyRule rule;

        [SetUp]
        public void Setup()
        {
            this.rule = new MinimalAgeRule();
        }

        [Test]
        public void Test_ShouldBeTrue_When_AgeIs0()
        {
            //Given
            Solicitud solicitud = new Solicitud();
            solicitud.Cliente = new Cliente {
                FechaNacimiento = System.DateTime.Today
            };

            //When
            bool result = this.rule.Check(solicitud);
            //Then
            Assert.IsTrue(result);
        }

        [Test]
        public void Test_ShouldBeFalse_When_AgeIs18()
        {
            //Given
            Solicitud solicitud = new Solicitud();
            solicitud.Cliente = new Cliente {
                FechaNacimiento = DateTime.Today.AddMonths(-1 * 12 * 18)
            };

            //When
            bool result = this.rule.Check(solicitud);
            //Then
            Assert.IsFalse(result);
        }

        [Test]
        public void Test_ShouldBeFalse_When_AgeGreaterThan18()
        {
            //Given
            Solicitud solicitud = new Solicitud();
            solicitud.Cliente = new Cliente {
                FechaNacimiento = DateTime.Today.AddMonths(-1 * 12 * 25)
            };

            //When
            bool result = this.rule.Check(solicitud);
            //Then
            Assert.IsFalse(result);
        }
    }
}
