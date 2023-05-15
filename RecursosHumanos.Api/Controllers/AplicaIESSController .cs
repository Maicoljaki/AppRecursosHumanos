using Microsoft.AspNetCore.Mvc;
using RecursosHumanos.Api.Services.AplicaIESSService;

namespace RecursosHumanos.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AplicaIESSController : RecursosHumanosApi
{
    private readonly IAplicaIESSService _service;

    public AplicaIESSController(IAplicaIESSService aplicaIESSService)
    {
        _service = aplicaIESSService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var aplicaIessresult = await _service.GetAll();
        return aplicaIessresult.Match(Ok, Problem);
    }
}
