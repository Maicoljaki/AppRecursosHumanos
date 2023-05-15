using Newtonsoft.Json;

namespace RecursosHumanos.Api.DTO.Ecuasol;

public class EcuasolTipoOperacion
{
    [JsonProperty("NombreOperacion")]
    public string Codigo { get; set; } = string.Empty;

    [JsonProperty("CodigoTipooperacion")]
    public string Nombre { get; set; } = string.Empty;
}