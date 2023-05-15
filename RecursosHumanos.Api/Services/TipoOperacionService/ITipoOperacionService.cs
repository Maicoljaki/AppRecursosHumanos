using ErrorOr;
using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Api.Services.TipoOperacionService;

public interface ITipoOperacionService
{
    public Task<ErrorOr<List<TipoOperacion>>> GetAll();
}
