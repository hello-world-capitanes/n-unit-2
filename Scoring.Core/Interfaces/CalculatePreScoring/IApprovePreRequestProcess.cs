
using Scoring.Model.Entities;

namespace Scoring.Core.Interfaces.CalculatePreScoring
{
    public interface IApprovePreRequestProcess
    {
        bool ApprovedRules(Solicitud solicitud);
    }
}
