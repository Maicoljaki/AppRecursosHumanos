using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecursosHumanos.Api.Services.EmisorService;

namespace RecursosHumanos.Api.Controllers;

[Route("api/[controller]")]
public class EmisorController : RecursosHumanosApi
{
    private IEmisorService _emisorService;

    public EmisorController(IEmisorService emisorService)
    {
        _emisorService = emisorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var emisoresResult = await _emisorService.GetAll();
        return emisoresResult.Match(Ok, Problem);
    }
}
