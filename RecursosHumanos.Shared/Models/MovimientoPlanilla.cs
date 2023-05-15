namespace RecursosHumanos.Shared.Models;

public record MovimientoPlanilla(
    int CodigoConcepto,
    string Concepto,
    int Prioridad,
    string TipoOperacion,
    string Cuenta1,
    string Cuenta2,
    string Cuenta3,
    string Cuenta4,
    string MovimientoExcepcion1,
    string MovimientoExcepcion2,
    string MovimientoExcepcion3,
    string AplicaIESS,
    string AplicaImpRenta,
    string EmpresaAfectaIESS,
    string? Mensaje = null);