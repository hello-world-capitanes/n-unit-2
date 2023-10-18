
using Scoring.Model.Entities;

namespace Scoring.Core.Interfaces.CalculatePreScoring
{
    public interface IDenyPreRequestProcess
    {
        bool DeniedAnyRule(Solicitud solicitud );
        
    }
}
