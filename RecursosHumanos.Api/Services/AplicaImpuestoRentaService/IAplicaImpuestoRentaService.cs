using ErrorOr;
using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Api.Services.AplicaImpuestoRentaService;

public interface IAplicaImpuestoRentaService
{
    public Task<ErrorOr<List<AplicaImpuestoRenta>>> GetAll();
}
