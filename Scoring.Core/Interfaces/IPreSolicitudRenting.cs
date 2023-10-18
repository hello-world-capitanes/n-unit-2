
using Scoring.Model;
using Scoring.Model.Entities;

namespace Scoring.Core.Interfaces
{
    public interface IPreSolicitudRenting
    {
        EstadoPreSolicitud CalculatePreRequest(Solicitud solicitud );
        
    }
}
