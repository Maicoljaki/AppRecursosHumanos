using ErrorOr;
using RecursosHumanos.Shared.Models;
using RecursosHumanos.Shared.Requests;

namespace RecursosHumanos.Api.Services.MovimientoPlanillaService;

public interface IMovimientoPlanillaService
{
    public Task<ErrorOr<List<MovimientoPlanilla>>> GetAll();
    public Task<ErrorOr<MovimientoPlanillaSimple>> Insert(InsertMovimientoPlanillaRequest request);
    public Task<ErrorOr<MovimientoPlanillaSimple>> Update(UpdateMovimientoPlanillaRequest request);
    public Task<ErrorOr<MovimientoPlanillaSimple>> Delete(DeleteMovimientoPlanillaRequest request);
}
