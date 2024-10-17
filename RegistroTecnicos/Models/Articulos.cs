using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Articulos
{
    [Key]
    public int ArticuloId { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Solo se permiten numeros enteros o decimales")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public double Costo { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public double Precio { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public int Existencia { get; set; }
}
