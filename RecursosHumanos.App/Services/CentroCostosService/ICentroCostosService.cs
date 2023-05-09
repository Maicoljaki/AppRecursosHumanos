using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.App.Services.CentroCostosService;

public interface ICentroCostosService
{
    public Task<List<CentroCostos>> GetAll();
    public Task<CentroCostos> GetByCodigo(int Id);
    public Task Update(CentroCostos centroCostos);
    public Task Insert(CentroCostos centroCostos);
    public Task Delete(CentroCostos centroCostos);
}
