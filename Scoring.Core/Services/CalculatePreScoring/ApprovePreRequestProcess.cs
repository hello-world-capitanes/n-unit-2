
using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Model.Entities;
using System.Runtime.InteropServices;

namespace Scoring.Core.Services.CalculatePreScoring
{
    public class ApprovePreRequestProcess : IApprovePreRequestProcess
    {
        private readonly IApprovingRule approvingRule;
        Asalariado asalariado1;
        CheckInversionIngresosNetos ingresosNetos;
        CheckInversionTotal inversionTotal;
        //Nacionalidad

        public ApprovePreRequestProcess (IApprovingRule asalariado1, IApprovingRule ingresosNetos)
        {
            this.asalariado1 = asalariado1; //Deberia funcionar, asi lo hace Roi
        }
        public bool ApprovedRules(Solicitud solicitud)
        {            
            return asalariado1.Check(solicitud) && ingresosNetos.Check(solicitud) && inversionTotal.Check(solicitud);
        }



    }
}
