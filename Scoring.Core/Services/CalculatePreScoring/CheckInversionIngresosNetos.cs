using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.Core.Services.CalculatePreScoring
{
    public class CheckInversionIngresosNetos : IApprovingRule
    {
        public bool Check(Solicitud solicitud)
        {
            double inversion = solicitud.Inversion;
            double ingresosNeto = solicitud.cliente.IngresosNetosAnualesAsalariado + solicitud.cliente.IngresosNetosAnualesAutonomo;
            return inversion <= ingresosNeto;
        }
    }
}
