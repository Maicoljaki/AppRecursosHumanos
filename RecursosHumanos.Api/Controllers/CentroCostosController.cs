using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecursosHumanos.Api.Services.CentroCostosService;
using RecursosHumanos.Shared.Models;
using RecursosHumanos.Shared.Requests;

namespace RecursosHumanos.Api.Controllers
{
    [Route("api/[controller]")]
    public class CentroCostosController : RecursosHumanosApi
    {
        private ICentroCostosService _centroCostosService;

        public CentroCostosController(ICentroCostosService centroCostosService)
        {
            _centroCostosService = centroCostosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var centroCostosResult = await _centroCostosService.GetAll();
            return centroCostosResult.Match(Ok, Problem);
        }

        [HttpGet("getByCodigo")]
        public async Task<IActionResult> GetByCodigo(int codigo)
        {
            var centroCostosResult = await _centroCostosService.GetAll();
            return centroCostosResult.Match(
                (r) => Ok(r.FirstOrDefault(p => p.Codigo == codigo) ?? new(0, "")),
                Problem);
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Insert(CentroCostosRequest request)
        {
            var centroCostosResult = await _centroCostosService.Insert(request.Codigo, request.Nombre);
            return centroCostosResult.Match(Ok, Problem);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(CentroCostosRequest request)
        {
            var centroCostosResult = await _centroCostosService.Update(request.Codigo, request.Nombre);
            return centroCostosResult.Match(Ok, Problem);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(CentroCostosRequest request)
        {
            var centroCostosResult = await _centroCostosService.Delete(request.Codigo, request.Nombre);
            return centroCostosResult.Match(Ok, Problem);
        }
    }
}
