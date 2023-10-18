using System;

namespace Scoring.Model.Entities
{
    public class Cliente
    {

        public DateTime FechaDeNacimiento { get; set; }
        public double IngresosNetosAnualesAsalariado { get; set; }
        public double IngresosNetosAnualesAutonomo { get; set; }
        public double IngresosBrutosAnualesAutonomo { get; set; }
        public string Nacionalidad { get; set; }
        public string CifEmpleador { get; set; }
        

    }
}