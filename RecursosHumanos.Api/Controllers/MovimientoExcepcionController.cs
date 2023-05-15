using Microsoft.AspNetCore.Mvc;
using RecursosHumanos.Api.Services.MovimientoExcepcionService;

namespace RecursosHumanos.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovimientoExcepcionController : RecursosHumanosApi
{
    private readonly IMovimientoExcepcionService _service;

    public MovimientoExcepcionController(IMovimientoExcepcionService movimientoExcepcionService)
    {
        _service = movimientoExcepcionService;
    }

    [HttpGet("1y2")]
    public async Task<IActionResult> GetAll1y2()
    {
        var movimientos = await _service.GetAll1y2();
        return movimientos.Match(Ok, Problem);
    }

    [HttpGet("3")]
    public async Task<IActionResult> GetAll3()
    {
        var movimientos = await _service.GetAll3();
        return movimientos.Match(Ok, Problem);
    }
}
