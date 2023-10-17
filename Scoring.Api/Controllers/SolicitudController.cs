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

            _llamadaService.LogLLamada(new LlamadaEntity {
                UrlOrigen = base.GetUrlOrigen(),
                LlamServicio = base.GetUrlDestino(),
                ParaEntrada = base.GetParamsEntrada(),
                ParaSalida = "",
                Observaciones = "",
            });

            bool resultado = this._preSolicitud.CalculatePreRequest();

            return Ok();


            /*List<ApiServicioParametroEntity> parametros = this.GetQueryParamsColegiados(HttpContext.Request.Query);
            
            OdooResponse colegiadoResponse = new OdooResponse();
            try
            {
                colegiadoResponse = await _colegiadoService.ProcessGetColegiadosFromOdooApi(token, base.GetUrlOrigen(), parametros);
                if(colegiadoResponse != null)
                {
                    HttpContext.Response.Headers.Add("X-Total-Count", colegiadoResponse.TotalElments.ToString());
                }

            }
            catch (ErrorTokenExternoFarmException ex)
            {
                base.RegistraFarmErrorLlamada(ex);
                try
                {
                   parametros = this.GetQueryParamsColegiados(HttpContext.Request.Query);
                   colegiadoResponse = await _colegiadoService.RetryGetColegiadosFromOdooApiNoExternalToken(token, base.GetUrlOrigen(), parametros);
                   HttpContext.Response.Headers.Add("X-Total-Count", colegiadoResponse.TotalElments.ToString());
                } catch(Exception generalEx)
                {
                    _logger.LogError("Error no controlado. ", generalEx);
                    return StatusCode(500, new ErrorModel {
                        Code = 999,
                        Message = "Ha ocurrido un error. Inténtelo de nuevo más tarde. Si el error persiste contacte con su administrador"
                    });
                }
            }
            catch (FarmException ex)
            {
                base.RegistraFarmErrorLlamada(ex);
                return StatusCode(ex.HttpCode, new ErrorModel {
                    Code = ex.InternalCode,
                    Message = ex.InternalMessage
                });
            } catch(Exception ex)
            {
                _logger.LogError("Error no controlado. ", ex);
                return StatusCode(500, new ErrorModel {
                    Code = 999,
                    Message = "Ha ocurrido un error. Inténtelo de nuevo más tarde. Si el error persiste contacte con su administrador"
                });
            }

            _ = _llamadaService.InsertLLamada(new LlamadaEntity {
                Lla_UrlOrigen = base.GetUrlOrigen(),
                Lla_LlamServicio = base.GetUrlDestino(),
                Lla_ParaEntrada = base.GetParamsEntrada(),
                Lla_ParaSalida = colegiadoResponse.BodyResponse,
                Lla_Observaciones = "",
                Uss_Id = colegiadoResponse.UserServiceToken.userServiceId,
                Tkn_Id = colegiadoResponse.UserServiceToken.tokenId

            });

            return Ok(colegiadoResponse.BodyResponse);
            */
        }

    }
}
