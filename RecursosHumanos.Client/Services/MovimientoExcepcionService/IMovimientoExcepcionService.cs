using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Client.Services.MovimientoExcepcionService;

public interface IMovimientoExcepcionService
{
    public Task<List<MovimientoExcepcion>> GetAll1y2();
    public Task<List<MovimientoExcepcion>> GetAll3();
}
