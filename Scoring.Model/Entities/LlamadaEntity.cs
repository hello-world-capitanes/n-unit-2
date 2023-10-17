using System;

namespace Scoring.Model.Entities
{
    public class LlamadaEntity
    {
        public int Id { get; set; }
        public string UrlOrigen { get; set; }
        public string LlamServicio { get; set; }
        public string ParaEntrada { get; set; }
        public string ParaSalida { get; set; }
        public DateTime FecLlamada { get; set; }
        public string Observaciones { get; set; }
        
    }
}
