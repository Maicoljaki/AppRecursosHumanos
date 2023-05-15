namespace RecursosHumanos.Shared.Requests;

public record InsertMovimientoPlanillaRequest(
    string Concepto,
    int Prioridad,
    string CodigoTipoOperacion,
    string Cuenta1,
    string Cuenta2,
    string Cuenta3,
    string Cuenta4,
    string CodigoMovimientoExcepcion1,
    string CodigoMovimientoExcepcion2,
    string CodigoMovimientoExcepcion3,
    string CodigoAplicaIESS,
    string CodigoAplicaImpRenta,
    string CodigoEmpresaAfectaIESS,
    string? Mensaje = null);
