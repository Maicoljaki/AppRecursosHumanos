using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.App.Data.Forms;

public class CentroCostosForm
{
    [Required(ErrorMessage = "El codigo es obligatorio")]
    public int Codigo { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; } = string.Empty;
}
