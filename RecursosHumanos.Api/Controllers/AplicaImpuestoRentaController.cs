using Microsoft.AspNetCore.Mvc;
using RecursosHumanos.Api.Services.AplicaImpuestoRentaService;

namespace RecursosHumanos.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AplicaImpuestoRentaController : RecursosHumanosApi
{
    private readonly IAplicaImpuestoRentaService _service;

    public AplicaImpuestoRentaController(IAplicaImpuestoRentaService aplicaImpuestoRentaService)
    {
        _service = aplicaImpuestoRentaService;        
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var impuestosResult = await _service.GetAll();
        return impuestosResult.Match(Ok, Problem);
    }
}
