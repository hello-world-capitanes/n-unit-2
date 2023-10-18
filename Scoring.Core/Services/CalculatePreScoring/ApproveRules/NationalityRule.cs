using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Model.Entities;
using System;


namespace Scoring.Core.Services.CalculatePreScoring.ApproveRules
{
    public class NationalityRule : IApproveRule
    {
        private const string NACIONALIDAD_APROBAR = "es";

        public bool Check(Solicitud solicitud)
        {
            if(solicitud.Cliente.Nacionalidad != null && solicitud.Cliente.Nacionalidad.ToLower() == NACIONALIDAD_APROBAR)
            {
                return true;
            }
            return false;
        }
    }
}
