using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.Model.Entities
{
    public class Solicitud
    {
        public Solicitud()
        {
            this.FechaSolicitud = DateTime.Now;
        }

        public DateTime FechaSolicitud { get; }
        public float Inversion { get; set; }
        public float Cuota { get; set; }

        public int PlazoMeses { get; set; }

        public DateTime FechaInicioVigor{ get; set; }

        public Cliente Cliente { get; set; }
    }
}
