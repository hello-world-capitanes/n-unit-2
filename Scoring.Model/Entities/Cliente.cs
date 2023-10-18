using System;

namespace Scoring.Model.Entities
{
    public class Cliente
    {
        public DateTime FechaNacimiento { get; set; }
        public float IngresosNetosAsalariado { get; set; }
        public float IngresosNetosAutonomo { get; set; }
        public float IngresosBrutosAutonomo { get; set; }

        public DateTime? FechaInicioEmpleoAsalariado { get; set; }

        public string Nacionalidad { get; set; }

        public string CifEmpleador { get; set; }

    }
}