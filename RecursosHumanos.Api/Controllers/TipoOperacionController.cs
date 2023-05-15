using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecursosHumanos.Api.Services.TipoOperacionService;

namespace RecursosHumanos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoOperacionController : RecursosHumanosApi
    {
        private readonly ITipoOperacionService _tipoOperacionService;

        public TipoOperacionController(ITipoOperacionService tipoOperacionService)
        {
            _tipoOperacionService = tipoOperacionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tiposResult = await _tipoOperacionService.GetAll();
            return tiposResult.Match(Ok, Problem);
        }
    }
}
