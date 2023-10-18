
using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Model.Entities;
using System.Runtime.InteropServices;

namespace Scoring.Core.Services.CalculatePreScoring
{
    public class ApprovePreRequestProcess : IApprovePreRequestProcess
    {
        private readonly IApprovingRule approvingRule;

        public ApprovePreRequestProcess (IApprovingRule approvingRule)
        {
            this.approvingRule = approvingRule;
        }
        public bool ApprovedRules(Solicitud solicitud)
        {
            return approvingRule.Check(solicitud);
            
        }



    }
}
