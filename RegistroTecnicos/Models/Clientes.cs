using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Clientes
{
    [Key]
    public int ClienteId { get; set; }

    [Required(ErrorMessage ="Campo obligatorio")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten letras")]
    public string? Nombres { get; set; }

    [Required(ErrorMessage ="Campo obligatorio")]
    [RegularExpression(@"^\d+$", ErrorMessage ="Solo se permiten numeros enteros")]
    public string? WhatsApp { get; set; }
}
