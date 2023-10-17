using Scoring.Model.Entities;
using Scoring.Core.Interfaces;
using Scoring.Logger;

namespace Scoring.Core.Services
{
    
    public class LlamadaService : ILlamadaService
    {
        private readonly ILogger _logger;

        public LlamadaService(ILogger logger)
        {
            _logger = logger;
        }

        public void LogLLamada(LlamadaEntity llamada)
        {
            string message = Newtonsoft.Json.JsonConvert.SerializeObject(llamada);

            _logger.LogDebug(message);           
        }
       
     
       
    }
}
