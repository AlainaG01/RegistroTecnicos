using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Prioridades
{
    [Key]
    public int PrioridadesId {  get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo letras")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Solo números naturales")]
    public int Tiempo { get; set; }
}
