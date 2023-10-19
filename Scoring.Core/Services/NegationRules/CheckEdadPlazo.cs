using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.Core.Services.DenegateRules
{
    public class CheckEdadPlazo : INegationRule
    {
        public CheckEdadPlazo() {
        
        }

        public bool Check (Solicitud solicitud)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - solicitud.cliente.FechaDeNacimiento.Year;
            int months = now.Month - solicitud.cliente.FechaDeNacimiento.Month;
            int days = now.Day - solicitud.cliente.FechaDeNacimiento.Day;

            if (days < 0)
            {
                months--;
            }

            if (months < 0)
            {
                age--;
            }

            int totalAge = age + (solicitud.Plazo / 12);

            return totalAge >= 80;

        }

    }
}
