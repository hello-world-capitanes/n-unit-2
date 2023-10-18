using Scoring.Model.Entities;


namespace Scoring.Core.Interfaces.CalculatePreScoring
{
    public interface IDenyRule
    {
        bool Check(Solicitud solicitud);
    }
}
