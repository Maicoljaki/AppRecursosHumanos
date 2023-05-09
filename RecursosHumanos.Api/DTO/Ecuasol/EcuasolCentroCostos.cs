using Newtonsoft.Json;

namespace RecursosHumanos.Api.DTO.Ecuasol;

public class EcuasolCentroCostos
{
    [JsonProperty("Codigo")]
    public int Codigo { get; set; }

    [JsonProperty("NombreCentroCostos")]
    public string Nombre { get; set; } = string.Empty;
}
