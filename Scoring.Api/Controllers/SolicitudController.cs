using Scoring.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scoring.Core.Interfaces;
using Scoring.Logger;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scoring.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : RentingBaseController
    {

        private readonly IPreSolicitudRenting _preSolicitud;
        private readonly ILogger _logger;
        

        public SolicitudController(IPreSolicitudRenting preSolicitud, ILlamadaService llamadaService, ILogger logger) : base(llamadaService)
        {            
            _logger = logger;
            _preSolicitud = preSolicitud;
        }

        [HttpGet]
        public IActionResult CalculatePreScoring() {

            _logger.LogDebug("calculatePreScoring.");
            base.RegistraInicioLlamada();

            bool resultado = this._preSolicitud.CalculatePreRequest();

            _llamadaService.LogLLamada(new LlamadaEntity {
                UrlOrigen = base.GetUrlOrigen(),
                LlamServicio = base.GetUrlDestino(),
                ParaEntrada = base.GetParamsEntrada(),
                ParaSalida = "",
                Observaciones = "",
            });

            return Ok();
           
        }

    }
}
