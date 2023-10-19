using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Model.Entities;
using System;


namespace Scoring.Core.Services.CalculatePreScoring.ApproveRules
{
    public class InvestmentLowerThanLimitRule : IApproveRule
    {
        private const float INVESTMENT_LIMIT = 80000;

        public bool Check(Solicitud solicitud)
        {
            return solicitud.Inversion < INVESTMENT_LIMIT;
        }
    }
}
