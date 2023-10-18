

using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Model.Entities;
using System;

namespace Scoring.Core.Services.CalculatePreScoring.DenyRules
{
    public class MinimalAgeRule : IDenyRule
    {

        private const int MINIMAL_AGE = 18;
        public bool Check(Solicitud solicitud)
        {
            int age = DateTime.Today.Subtract(solicitud.Cliente.FechaNacimiento).Days/365;
            return age < MINIMAL_AGE;
        }
    }
}
