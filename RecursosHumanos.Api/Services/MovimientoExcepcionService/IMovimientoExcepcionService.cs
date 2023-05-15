using ErrorOr;
using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Api.Services.MovimientoExcepcionService;

public interface IMovimientoExcepcionService
{
    public Task<ErrorOr<List<MovimientoExcepcion>>> GetAll1y2();
    public Task<ErrorOr<List<MovimientoExcepcion>>> GetAll3();
}
