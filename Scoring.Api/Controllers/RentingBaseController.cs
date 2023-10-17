using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using Scoring.Core.Interfaces;
using Scoring.Model.Entities;
using Scoring.Exceptions;

namespace Scoring.Api.Controllers
{
    public abstract class RentingBaseController : ControllerBase
    {
        protected readonly ILlamadaService _llamadaService;

        protected RentingBaseController(ILlamadaService llamadaService)
        {
            _llamadaService = llamadaService;
        }

        protected string GetUrlOrigen()
        {
            if(HttpContext.Request.GetTypedHeaders().Referer == null || string.IsNullOrEmpty(HttpContext.Request.GetTypedHeaders().Referer.ToString()))
            {
                return string.Empty;
            } else
            {
                return HttpContext.Request.GetTypedHeaders().Referer.ToString();
            }            
        }

        protected string GetUrlDestino()
        {
            return HttpContext.Request.GetDisplayUrl();
        }

        protected string GetParamsEntrada()
        {
            return GetUrlDestino().Substring(GetUrlDestino().IndexOf("?") + 1);
        }

        protected void RegistraInicioLlamada()
        {
            //Llamada inicio proceso
            _llamadaService.LogLLamada(new LlamadaEntity {
                UrlOrigen = this.GetUrlOrigen(),
                LlamServicio = this.GetUrlDestino(),
                ParaEntrada = this.GetParamsEntrada()
            });
        }

        protected void RegistraFarmErrorLlamada(ScoringException ex)
        {
            _llamadaService.LogLLamada(new LlamadaEntity {
                UrlOrigen = this.GetUrlOrigen(),
                LlamServicio = this.GetUrlDestino(),
                ParaEntrada = this.GetParamsEntrada(),
                Observaciones = ex.LlamadaObservaciones,                
            });
        }
    }
}
