using Scoring.Core.Interfaces;
using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Model;
using Scoring.Model.Entities;

namespace Scoring.Core.Services
{
    public class PreSolicitudRenting : IPreSolicitudRenting
    {
        IApprovePreRequestProcess _approvePreRequestProcess;
        IDenyPreRequestProcess _denyPreRequestProcess;

        public PreSolicitudRenting(IApprovePreRequestProcess approvePreRequestProcess, IDenyPreRequestProcess denyPreRequestProcess)
        {
            _approvePreRequestProcess = approvePreRequestProcess;
            _denyPreRequestProcess = denyPreRequestProcess;
        }

        public EstadoPreSolicitud CalculatePreRequest(Solicitud solicitud)
        {
            if (_denyPreRequestProcess.DeniedAnyRule(solicitud))
            {
                return EstadoPreSolicitud.PreDenegeda;
            } else if (_approvePreRequestProcess.ApproveAllRules(solicitud)){
                return EstadoPreSolicitud.PreAceptada;
            } else
            {
                return EstadoPreSolicitud.PendienteAnalista;
            }
        }
    }
}
