using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Scoring.Core.Services.CalculatePreScoring
{
    public class DenyPreRequestProcess : IDenyPreRequestProcess
    {
        List<IDenyRule> _denyRules;
        public DenyPreRequestProcess(IEnumerable<IDenyRule> denyRules)
        {
            _denyRules = denyRules.ToList();
        }
        public bool DeniedAnyRule(Solicitud solicitud)
        {
            foreach (IDenyRule rule in _denyRules)
            {
                if (rule.Check(solicitud))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
