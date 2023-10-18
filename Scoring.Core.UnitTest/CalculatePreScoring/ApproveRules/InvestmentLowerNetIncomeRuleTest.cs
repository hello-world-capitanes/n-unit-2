using NUnit.Framework;
using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Core.Services.CalculatePreScoring.ApproveRules;
using Scoring.Model.Entities;

namespace Scoring.Core.UnitTest.CalculatePreScoring.ApproveRules
{


    public class InvestmentLowerNetIncomeRuleTest
    {

        private IApproveRule rule;

        [SetUp]
        public void Setup()
        {
            this.rule = new InvestmentLowerNetIncomeRule();            
        }

        [Test]
        public void Test_ShouldBeTrue_When_AllFiguresAre0()
        {
            //Given
            Solicitud solicitud = new Solicitud();
            solicitud.Inversion = 0;
            solicitud.Cliente = new Cliente();

            //When
            bool result = this.rule.Check(solicitud);
            //Then
            Assert.IsTrue(result);
        }

        [Test]
        public void Test_ShouldBeTrue_When_InvestmentIsLowerThanEmployeeNetIncomeAndSelfEmployeeIs0()
        {
            //Given
            Solicitud solicitud = new Solicitud();
            solicitud.Inversion = 12000;
            solicitud.Cliente = new Cliente {
                IngresosNetosAsalariado = 25000
            };

            //When
            bool result = this.rule.Check(solicitud);
            //Then
            Assert.IsTrue(result);
        }

        [Test]
        public void Test_ShouldBeTrue_When_InvestmentIsEqualThanEmployeeNetIncomeAndSelfEmployeeIs0()
        {
            //Given
            Solicitud solicitud = new Solicitud();
            solicitud.Inversion = 25000;
            solicitud.Cliente = new Cliente {
                IngresosNetosAsalariado = 25000
            };

            //When
            bool result = this.rule.Check(solicitud);
            //Then
            Assert.IsTrue(result);
        }

        [Test]
        public void Test_ShouldBeFalse_When_InvestmentIsGreaterThanEmployeeNetIncomeAndSelfEmployeeIs0()
        {
            //Given
            Solicitud solicitud = new Solicitud();
            solicitud.Inversion = 45000;
            solicitud.Cliente = new Cliente {
                IngresosNetosAsalariado = 25000
            };

            //When
            bool result = this.rule.Check(solicitud);
            //Then
            Assert.IsFalse(result);
        }

        [Test]
        public void Test_ShouldBeTrue_When_InvestmentIsLowerThanSelfEmployeeNetIncomeAndEmployeeIs0()
        {
            //Given
            Solicitud solicitud = new Solicitud();
            solicitud.Inversion = 12000;
            solicitud.Cliente = new Cliente {
                IngresosNetosAutonomo = 25000
            };

            //When
            bool result = this.rule.Check(solicitud);
            //Then
            Assert.IsTrue(result);
        }

        [Test]
        public void Test_ShouldBeTrue_When_InvestmentIsEqualThanSelfEmployeeNetIncomeAndEmployeeIs0()
        {
            //Given
            Solicitud solicitud = new Solicitud();
            solicitud.Inversion = 25000;
            solicitud.Cliente = new Cliente {
                IngresosNetosAutonomo = 25000
            };

            //When
            bool result = this.rule.Check(solicitud);
            //Then
            Assert.IsTrue(result);
        }

        [Test]
        public void Test_ShouldBeFalse_When_InvestmentIsGreaterThanSelfEmployeeNetIncomeAndEmployeeIs0()
        {
            //Given
            Solicitud solicitud = new Solicitud();
            solicitud.Inversion = 45000;
            solicitud.Cliente = new Cliente {
                IngresosNetosAutonomo = 25000
            };

            //When
            bool result = this.rule.Check(solicitud);
            //Then
            Assert.IsFalse(result);
        }

        [Test]
        public void Test_ShouldBeTrue_When_InvestmentIsLowerThanSumEmployeeAndSelfEmployeeNetIncome()
        {
            //Given
            Solicitud solicitud = new Solicitud();
            solicitud.Inversion = 25000;
            solicitud.Cliente = new Cliente {
                IngresosNetosAutonomo = 15000,
                IngresosNetosAsalariado = 15000
            };

            //When
            bool result = this.rule.Check(solicitud);
            //Then
            Assert.IsTrue(result);
        }

        [Test]
        public void Test_ShouldBeTrue_When_InvestmentEqualThanSumEmployeeAndSelfEmployeeNetIncome()
        {
            //Given
            Solicitud solicitud = new Solicitud();
            solicitud.Inversion = 30000;
            solicitud.Cliente = new Cliente {
                IngresosNetosAutonomo = 15000,
                IngresosNetosAsalariado = 15000
            };

            //When
            bool result = this.rule.Check(solicitud);
            //Then
            Assert.IsTrue(result);
        }

        [Test]
        public void Test_ShouldBeFalse_When_InvestmentGreaterThanSumEmployeeAndSelfEmployeeNetIncome()
        {
            //Given
            Solicitud solicitud = new Solicitud();
            solicitud.Inversion = 40000;
            solicitud.Cliente = new Cliente {
                IngresosNetosAutonomo = 15000,
                IngresosNetosAsalariado = 15000
            };

            //When
            bool result = this.rule.Check(solicitud);
            //Then
            Assert.IsFalse(result);
        }

    }
}
