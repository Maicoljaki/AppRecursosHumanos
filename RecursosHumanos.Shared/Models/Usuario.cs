
namespace RecursosHumanos.Shared.Models;

public record Usuario(
    string Nombre,
    string Empresa,
    DateTime Fecha)
{
    public char PrimeraLetra => Nombre.First();
}
