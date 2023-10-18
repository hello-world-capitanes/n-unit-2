using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.Core.Services.CalculatePreScoring
{
    public class CheckInversionTotal : IApprovingRule
    {

        public CheckInversionTotal()
        {
        }

        public bool Check(Solicitud solicitud)
        {
            return solicitud.Inversion <= 80000;
        }
    }
}
