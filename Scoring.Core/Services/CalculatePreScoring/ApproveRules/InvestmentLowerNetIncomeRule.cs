using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Model.Entities;

namespace Scoring.Core.Services.CalculatePreScoring.ApproveRules
{
    public class InvestmentLowerNetIncomeRule : IApproveRule
    {
        public bool Check(Solicitud solicitud)
        {
            float ingresosNetos = solicitud.Cliente.IngresosNetosAsalariado + solicitud.Cliente.IngresosNetosAutonomo;

            return solicitud.Inversion <= ingresosNetos;
        }
    }
}
