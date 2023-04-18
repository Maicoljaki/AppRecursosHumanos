namespace webapi.Models;
using Newtonsoft.Json;

public class EcuasolEmisor
{
    [JsonProperty("Codigo")]
    public int Codigo { get; set; }

    [JsonProperty("NombreEmisor")]
    public string NombreEmisor { get; set; } = string.Empty;

    [JsonProperty("Ruc")]
    public string Ruc { get; set; } = string.Empty;
}
