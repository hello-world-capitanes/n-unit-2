using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.Model.Entities
{
    public class Solicitud
    {
        public DateTime Fecha { get; set; }
        public double Inversion { get; set; }
        public double Cuota {  get; set; }
        public int Plazo { get; set; }
        public DateTime InicioRenting { get; set; }
        
        public Cliente cliente { get; set; }
    }
}
