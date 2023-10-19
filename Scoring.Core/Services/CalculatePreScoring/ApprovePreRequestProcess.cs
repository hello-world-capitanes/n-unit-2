
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

        public ApprovePreRequestProcess (IApprovingRule approvingRule)
        {
            this.approvingRule = approvingRule;
        }
        public bool ApprovedRules(Solicitud solicitud)
        {            
            return asalariado1.Check(solicitud) && ingresosNetos.Check(solicitud) && inversionTotal.Check(solicitud) && /*nacionalidad aqui*/;
        }



    }
}
