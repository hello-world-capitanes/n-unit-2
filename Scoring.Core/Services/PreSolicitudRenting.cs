using Scoring.Core.Interfaces;
using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Model.Entities;

namespace Scoring.Core.Services
{
    public class PreSolicitudRenting : IPreSolicitudRenting
    {
        IApprovePreRequestProcess _approvePreRequestProcess;

        public PreSolicitudRenting(IApprovePreRequestProcess approvePreRequestProcess)
        {
            _approvePreRequestProcess = approvePreRequestProcess;
        }

        public bool CalculatePreRequest(Solicitud solicitud)
        {
            return this._approvePreRequestProcess.ApprovedRules(solicitud);
            
        }
    }
}
