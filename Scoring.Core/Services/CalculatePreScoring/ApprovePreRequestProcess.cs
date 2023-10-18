
using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Scoring.Core.Services.CalculatePreScoring
{
    public class ApprovePreRequestProcess : IApprovePreRequestProcess
    {
        List<IApproveRule> _approveRules;
        public ApprovePreRequestProcess(IEnumerable<IApproveRule> approveRules)
        {
            _approveRules = approveRules.ToList();
        }

        public bool ApproveAllRules(Solicitud solicitud)
        {
            foreach(IApproveRule rule in _approveRules)
            {
                if (!rule.Check(solicitud))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
