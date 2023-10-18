using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.Core.Interfaces.CalculatePreScoring
{
    public class CheckInversionTotal : IApprovingRules
    {
        public bool ApprovedInversionTotal (Solicitud solicitud)
        {
            if (solicitud.Inversion <= 80000)
            {
                return true;
            }
            else
                return false;
        }
    }
}
