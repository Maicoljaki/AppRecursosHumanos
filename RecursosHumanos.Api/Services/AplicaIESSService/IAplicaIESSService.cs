using ErrorOr;
using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Api.Services.AplicaIESSService;

public interface IAplicaIESSService
{
    public Task<ErrorOr<List<AplicaIESS>>> GetAll();
}
