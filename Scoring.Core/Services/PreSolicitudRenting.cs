using Scoring.Core.Interfaces;
using Scoring.Core.Interfaces.CalculatePreScoring;

namespace Scoring.Core.Services
{
    public class PreSolicitudRenting : IPreSolicitudRenting
    {
        IApprovePreRequestProcess _approvePreRequestProcess;

        public PreSolicitudRenting(IApprovePreRequestProcess approvePreRequestProcess)
        {
            _approvePreRequestProcess = approvePreRequestProcess;
        }

        public bool CalculatePreRequest()
        {
            return this._approvePreRequestProcess.ApprovedRules();
            
        }
    }
}
