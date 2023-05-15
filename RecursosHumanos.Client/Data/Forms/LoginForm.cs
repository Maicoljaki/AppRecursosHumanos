using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Client.Data.Forms;

public class LoginForm
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "El usuario es obligatorio")]
    [RegularExpression(@"\d{4}", ErrorMessage = "El usuario deben ser exactamente cuatro digitos")]
    public string Usuario { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = "La contraseña es obligatoria")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "El Emisor es obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "El Emisor es obligatorio")]
    public int CodigoEmisor { get; set; }
}
