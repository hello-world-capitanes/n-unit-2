
using Scoring.Model.Entities;
using System;
using System.Linq.Expressions;

namespace Scoring.Core.Interfaces.CalculatePreScoring
{
    public interface IApprovePreRequestProcess
    {
        bool ApproveAllRules(Solicitud solicitud );
        
    }
}
