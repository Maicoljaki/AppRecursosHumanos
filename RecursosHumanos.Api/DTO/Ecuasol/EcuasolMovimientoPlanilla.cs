using Newtonsoft.Json;

namespace RecursosHumanos.Api.DTO.Ecuasol;

public class EcuasolMovimientoPlanilla
{
    [JsonProperty("CodigoConcepto")]
    public int CodigoConcepto { get; set; }

    [JsonProperty("Concepto")]
    public string Concepto { get; set; } = string.Empty;

    [JsonProperty("Prioridad")]
    public int Prioridad { get; set; }

    [JsonProperty("TipoOperacion")]
    public string TipoOperacion { get; set; } = string.Empty;

    [JsonProperty("Cuenta1")]
    public string Cuenta1 { get; set; } = string.Empty;

    [JsonProperty("Cuenta2")]
    public string Cuenta2 { get; set; } = string.Empty;

    [JsonProperty("Cuenta3")]
    public string Cuenta3 { get; set; } = string.Empty;

    [JsonProperty("Cuenta4")]
    public string Cuenta4 { get; set; } = string.Empty;

    [JsonProperty("MovimientoExcepcion1")]
    public string MovimientoExcepcion1 { get; set; } = string.Empty;

    [JsonProperty("MovimientoExcepcion2")]
    public string MovimientoExcepcion2 { get; set; } = string.Empty;

    [JsonProperty("MovimientoExcepcion3")]
    public string MovimientoExcepcion3 { get; set; } = string.Empty;

    [JsonProperty("Aplica_iess")]
    public string AplicaIESS { get; set; } = string.Empty;

    [JsonProperty("Aplica_imp_renta")]
    public string AplicaImpRenta { get; set; } = string.Empty;

    [JsonProperty("Empresa_Afecta_Iess")]
    public string EmpresaAfectaIess { get; set; } = string.Empty;

    [JsonProperty("Mensaje")]
    public string? Mensaje { get; set; }
}