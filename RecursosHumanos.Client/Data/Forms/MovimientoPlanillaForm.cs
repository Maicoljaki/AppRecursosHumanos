using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Client.Data.Forms;

public class MovimientoPlanillaForm
{
    public int CodigoConcepto { get; set; } = 0;

    [Required(AllowEmptyStrings = false, ErrorMessage = "El concepto es obligatorio")]
    public string Concepto { get; set; } = string.Empty;

    [Required(ErrorMessage = "La prioridad es obligatoria")]
    public int Prioridad { get; set; } = 1;

    [Required(AllowEmptyStrings = false, ErrorMessage = "El tipo de operacion es obligatorio")]
    public string CodigoTipoOperacion { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = "La cuenta 1 es obligatoria")]
    public string Cuenta1 { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = "La cuenta 2 es obligatoria")]
    public string Cuenta2 { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = "La cuenta 3 es obligatoria")]
    public string Cuenta3 { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = "La cuenta 4 es obligatoria")]
    public string Cuenta4 { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = "El movimiento de excepcion 1 es obligatorio")]
    public string CodigoMovimientoExcepcion1 { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = "El movimiento de excepcion 2 es obligatorio")]
    public string CodigoMovimientoExcepcion2 { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = "El movimiento de excepcion 3 es obligatorio")]
    public string CodigoMovimientoExcepcion3 { get; set; } = string.Empty;

    public string CodigoAplicaIESS { get; set; } = string.Empty;

    public string CodigoAplicaImpuestoRenta { get; set; } = string.Empty;

    public string CodigoEmpresaIESS { get; set; } = string.Empty;

    public string? Mensaje { get; set; } = null;
}