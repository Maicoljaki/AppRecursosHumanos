using ErrorOr;
using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Api.Services.CentroCostosService;

public interface ICentroCostosService
{
    public Task<ErrorOr<List<CentroCostos>>> GetAll();
    public Task<ErrorOr<CentroCostos>> Insert(int Codigo, string Nombre);
    public Task<ErrorOr<CentroCostos>> Update(int Codigo, string Nombre);
    public Task<ErrorOr<CentroCostos>> Delete(int Codigo, string Nombre);
}
