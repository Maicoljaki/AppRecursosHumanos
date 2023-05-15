using RecursosHumanos.Shared.Models;
using RecursosHumanos.Shared.Requests;

namespace RecursosHumanos.Client.Services.MovimientoPlanillaService;

public interface IMovimientoPlanillaService
{
    public Task<List<MovimientoPlanilla>> GetAll();
    public Task<MovimientoPlanilla> GetByCodigoConcepto(int codigoConcepto);
    public Task Insert(InsertMovimientoPlanillaRequest request);
    public Task Update(UpdateMovimientoPlanillaRequest request);
    public Task Delete(DeleteMovimientoPlanillaRequest item);
}
