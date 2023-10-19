
using Scoring.Model.Entities;

namespace Scoring.Core.Interfaces
{
    public interface IPreSolicitudRenting
    {
        bool CalculatePreRequest(Solicitud solicitud);
        
    }
}
