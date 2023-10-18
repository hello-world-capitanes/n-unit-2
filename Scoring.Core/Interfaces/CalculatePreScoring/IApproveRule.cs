using Scoring.Model.Entities;


namespace Scoring.Core.Interfaces.CalculatePreScoring
{
    public interface IApproveRule
    {
        bool Check(Solicitud solicitud);
    }
}
