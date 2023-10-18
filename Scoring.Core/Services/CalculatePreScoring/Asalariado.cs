using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.Core.Services.CalculatePreScoring
{
    public class Asalariado : IApprovingRule
    {

        public bool Check(Solicitud solicitud)
        {

            int comparoFechas = DateTime.Compare(solicitud.cliente.FechaInicioAsalariado, DateTime.Now); //result<0 si t1 es anterior a t2. =0 t1 es igual que t2, >0 el resto
            
            Informa informa = new Informa();
            bool tieneCIF = informa.CIFs.Contains(solicitud.cliente.CifEmpleador);

            return (comparoFechas <= 0 && tieneCIF );
              //  throw new NotImplementedException();
        }

    }
}
