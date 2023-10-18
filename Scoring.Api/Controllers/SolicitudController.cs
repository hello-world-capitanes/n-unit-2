using Scoring.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scoring.Core.Interfaces;
using Scoring.Logger;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Scoring.Model;

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

            Solicitud solicitud = new Solicitud();
            solicitud.Inversion = 15000;
            solicitud.Cuota = 250;
            Cliente cliente = new Cliente();
            cliente.CifEmpleador = "A25365895";
            cliente.FechaInicioEmpleoAsalariado = null;
            cliente.FechaNacimiento = new DateTime(1982, 12, 31);
            cliente.IngresosNetosAsalariado = 39000;
            cliente.IngresosBrutosAutonomo = 0;
            cliente.IngresosNetosAutonomo = 0;
            solicitud.Cliente = cliente;


            EstadoPreSolicitud preResultadoSolicitud = this._preSolicitud.CalculatePreRequest(solicitud);

            _llamadaService.LogLLamada(new LlamadaEntity {
                UrlOrigen = base.GetUrlOrigen(),
                LlamServicio = base.GetUrlDestino(),
                ParaEntrada = base.GetParamsEntrada(),
                ParaSalida = "",
                Observaciones = "",
            });

            return Ok(preResultadoSolicitud.ToString());
           
        }

    }
}
