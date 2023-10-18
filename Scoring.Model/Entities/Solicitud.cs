using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.Model.Entities
{
    public class Solicitud
    {
        public float Inversion { get; set; }
        public float Couta { get; set; }

        public Cliente cliente { get; set; }
    }
}
