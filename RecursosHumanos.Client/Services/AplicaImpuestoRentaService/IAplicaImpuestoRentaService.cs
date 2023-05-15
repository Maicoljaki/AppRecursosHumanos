using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Client.Services.AplicaImpuestoRentaService;

public interface IAplicaImpuestoRentaService
{
    public Task<List<AplicaImpuestoRenta>> GetAll();
}