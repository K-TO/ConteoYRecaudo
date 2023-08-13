using ConteoRecaudo.API.Models;
using ConteoRecaudo.Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConteoRecaudo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RecaudoController : ControllerBase
    {
        #region Members
        private readonly IRecaudoBusiness _business;
        #endregion

        #region Ctor
        public RecaudoController(IRecaudoBusiness business)
        {
            _business = business;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_business.GetFromDates(DateTime.Now.AddMonths(-1), DateTime.Now));
        }

        [HttpPost]
        public async Task<IActionResult> FilterReport(RecaudoFilter recaudoFilter)
        {
            if (recaudoFilter.FechaInicial.HasValue && recaudoFilter.FechaFinal.HasValue)
            {
                if (!string.IsNullOrEmpty(recaudoFilter.Estacion))
                {
                    return Ok(_business.GetFromDatesAndStation(recaudoFilter.FechaInicial.Value, recaudoFilter.FechaFinal.Value, recaudoFilter.Estacion));
                }
                else
                {
                    return Ok(_business.GetFromDates(recaudoFilter.FechaInicial.Value, recaudoFilter.FechaFinal.Value));
                }
            }
            var result = await _business.GetFromYear(recaudoFilter.Anio.Value, recaudoFilter.Estacion);
            return Ok(result);
        }
        #endregion
    }
}
