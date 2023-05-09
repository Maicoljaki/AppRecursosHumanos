using ErrorOr;
using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Api.Services.EmisorService;

public interface IEmisorService
{
    public Task<ErrorOr<List<Emisor>>> GetAll();
}
