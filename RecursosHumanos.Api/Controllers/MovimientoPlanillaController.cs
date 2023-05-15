using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecursosHumanos.Api.Services.MovimientoPlanillaService;
using RecursosHumanos.Shared.Requests;

namespace RecursosHumanos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoPlanillaController : RecursosHumanosApi
    {
        private readonly IMovimientoPlanillaService _service;

        public MovimientoPlanillaController(IMovimientoPlanillaService movimientoPlanillaService)
        {
            _service = movimientoPlanillaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movimientos = await _service.GetAll();
            return movimientos.Match(Ok, Problem);
        }

        [HttpGet("getByCodigoConcepto")]
        public async Task<IActionResult> GetByCodigo(int codigoConcepto)
        {
            var centroCostosResult = await _service.GetAll();
            return centroCostosResult.Match(
                (r) => Ok(r.FirstOrDefault(p => p.CodigoConcepto == codigoConcepto) ?? new(0, "", 0, "", "", "", "", "", "", "", "", "", "", "")),
                Problem);
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Insert(InsertMovimientoPlanillaRequest request)
        {
            var movimientoResult = await _service.Insert(request);
            return movimientoResult.Match(Ok, Problem);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateMovimientoPlanillaRequest request)
        {
            var movimientoResult = await _service.Update(request);
            return movimientoResult.Match(Ok, Problem);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteMovimientoPlanillaRequest request)
        {
            var movimientoResult = await _service.Delete(request);
            return movimientoResult.Match(Ok, Problem);
        }
    }
}
